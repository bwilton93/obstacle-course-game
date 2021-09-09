using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 60f;
    [SerializeField] float rotationSpeed = 20f;
    [SerializeField] float playerDrag = 10f;

    public Transform startMarker;
    public Transform endMarker;
    
    public GameObject worldGrid;
    public GameObject lift;
    public GameObject playerStats;
    
    private float waitTime = 0.5f;
    private float autoSpeed = 0.008f;
    
    private Vector3 currentPos;
    private Vector3 liftPos;
    private Vector3 targetPos;
    private Vector3 levelStartPos;
    
    public bool movementLocked = false;
    public bool moveToLift = false;
    public bool scoreAdded = false;
    private bool touchingLift;

    // Start is called before the first frame update
    void Start() {
        lift = GameObject.Find("Lift");
        playerStats = GameObject.Find("Player Stats Container");
        if(playerStats.GetComponent<PlayerStats>().levelscore == 1) {
            PrintInstructions();
        }
        liftPosition();

        levelStartPos = transform.position;

        GetComponent<Rigidbody>().drag = playerDrag;
    }

    void awake() {
    }

    // Player movement has to be in FixedUpdate due to the nature of AddForce
    void FixedUpdate() {
        if (!touchingLift) {
            movePlayer();
        }
    }

    // Update is called once per frame
    void Update() {
        touchingLift = lift.GetComponent<WinCondition>().touchingLift;

        if (touchingLift) {
            autoMovePlayer();
            playerStats.GetComponent<PlayerStats>().levelScore = 0;
        } else if (movementLocked) {

        }

        if (Input.GetKeyDown("r")) {
            // transform.position = levelStartPos;
            // GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
            resetLevel();
        }
    }

    void PrintInstructions() {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move the player with the arrow keys or WASD");
        Debug.Log("Try to avoid the walls while you navigate the course!");
        Debug.Log("How about opening the door first?");    
    }

    void movePlayer() {
        // Get the horizontal and vertical axis, default bound to arrow keys or WASD.
        // Range -1 to 1
        float horizontalTranslation = Input.GetAxis("Horizontal") * playerSpeed;
        float verticalTranslation = Input.GetAxis("Vertical") * playerSpeed;
        
        // This gets the camera angle and determines movement direction based on the result
        Vector3 input = Quaternion.Euler (0, worldGrid.transform.eulerAngles.y, 0) * new Vector3(horizontalTranslation, 0.0f, verticalTranslation);

        // This make the bean man rotate in the direction he is walking.
        // It only sets a rotation when there is an input
        // This prevents the character rotation from resetting to 0,0,0 when keys are released
        if ((horizontalTranslation != 0 || verticalTranslation != 0)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), Time.deltaTime * rotationSpeed);

        }

        GetComponent<Rigidbody>().AddForce(worldGrid.transform.forward * verticalTranslation);
        GetComponent<Rigidbody>().AddForce(worldGrid.transform.right * horizontalTranslation);
    }

    void autoMovePlayer() {
        GetComponent<Collider>().enabled = false;

        // Set the rotation of the player to face towards the lift
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * rotationSpeed);

        getCurrentPosition();
        setTargetPos();
        // Debug.Log(targetPos.z);

        // Move player to front of lift, then slide into lift area to complete level
        transform.position = Vector3.MoveTowards(currentPos, targetPos, autoSpeed);
        
        if(!moveToLift) {
            moveToLift = true;

            if(!scoreAdded) {
                playerStats.GetComponent<PlayerStats>().currentLevel++;
                scoreAdded = true;
            }
        }
        
        StartCoroutine(GameObject.Find("Canvas").GetComponent<FadeToBlack>().FadeBlackOutSquare(true));
        // Debug.Log(transform.position.z);
        // Debug.Log(targetPos.z);

        if(transform.position.z == targetPos.z) {
            if(playerStats.GetComponent<PlayerStats>().currentLevel == SceneManager.sceneCountInBuildSettings) {
                playerStats.GetComponent<PlayerStats>().currentLevel = 0;
            }
            // StartCoroutine(SceneTransitionTimer());
            SceneManager.LoadScene(playerStats.GetComponent<PlayerStats>().currentLevel);
        }
    }

    void getCurrentPosition() {
        currentPos = transform.position;
    }

    void liftPosition() {
        liftPos = lift.transform.position;
    }

    void setTargetPos() {
        if (!moveToLift) {
            targetPos = new Vector3(liftPos.x, 1f, liftPos.z + 1f);
        } else {
            targetPos = new Vector3(liftPos.x, 1f, liftPos.z - 0.5f);
        }
    }
    
    public void resetLevel() {
        SceneManager.LoadScene(playerStats.GetComponent<PlayerStats>().currentLevel);
        playerStats.GetComponent<PlayerStats>().totalScore -= playerStats.GetComponent<PlayerStats>().levelScore;
        playerStats.GetComponent<PlayerStats>().levelScore = 0;
    }

    // DON'T DELETE THIS.
    // This slows down the scene load, to prevent the fade in/out from breaking
    IEnumerator SceneTransitionTimer() {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(playerStats.GetComponent<PlayerStats>().currentLevel);
    }

    // *****
    // I don't think this actually does anything, disabling it doesn't break the game so we'll see.
    // Leaving it here commented out just in case.
    // 
    // This was something to do with constraining a player to the boundary,
    // but the new move method of AddForce seems to have made it redundant.
    // *****
    // private void OnCollisionStay(Collision other) {
    //     Vector3 previousPosition = new Vector3(transform.position.x, 1f, transform.position.z);
    //     transform.position = previousPosition;
    // }

}
