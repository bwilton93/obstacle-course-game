using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float rotationSpeed = 20f;

    public Transform startMarker;
    public Transform endMarker;
    public new Camera camera;
    public GameObject lift;
    private Vector3 currentPos;
    private Vector3 liftPos;
    private Vector3 targetPos;
    private bool touchingLift;
    private bool insideLift;

    // Start is called before the first frame update
    void Start() {
        PrintInstructions();
        lift = GameObject.Find("Lift");
        liftPosition();
    }

    // Update is called once per frame
    void Update() {
        touchingLift = lift.GetComponent<WinCondition>().touchingLift;

        if (!touchingLift) {
            movePlayer();
        } else if (touchingLift && !insideLift) {
            autoMovePlayer();
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
        float horizontalTranslation = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalTranslation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        
        // This gets the camera angle and determines movement direction based on the result
        Vector3 input = Quaternion.Euler (0, camera.transform.eulerAngles.y, 0) * new Vector3(horizontalTranslation, 0.0f, verticalTranslation);

        transform.position += input;

        // This make the bean man rotate in the direction he is walking.
        // It only sets a rotation when there is an input
        // This prevents the character rotation from resetting to 0,0,0 when keys are released
        if ((horizontalTranslation != 0 || verticalTranslation != 0)) {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), Time.deltaTime * rotationSpeed);
        }
    }

    void autoMovePlayer() {
        GetComponent<Collider>().enabled = false;

        // Set the rotation of the player to face towards the lift
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, -180, 0), Time.deltaTime * rotationSpeed);

        getCurrentPosition();
        setTargetPos();

        // Move player to front of lift, then slide into lift area to complete level
        transform.position = Vector3.Lerp(currentPos, targetPos, 0.01f);
    }

    void getCurrentPosition() {
        currentPos = transform.position;
    }

    void liftPosition() {
        liftPos = lift.transform.position;
    }

    void setTargetPos() {
        targetPos = new Vector3(liftPos.x, 1f, liftPos.z - 0.5f);
    }
}
