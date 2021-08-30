using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public PlayerStats levelScore;
    public GameObject liftDoor;
    public bool levelComplete = false;
    public bool touchingLift = false;
    private int tempScore;

    // Start is called before the first frame update
    void Start() {
        levelScore = GameObject.Find("Player (Cappy)").GetComponent<PlayerStats>();
        liftDoor = GameObject.Find("Lift Door");
    }

    // Update is called once per frame
    void Update() {
        // For some reason I have to set up a temporary integer variable? 
        // This works though so just leave it.
        tempScore = levelScore.levelScore;
        
        // Checks if all 5 gems have been collected on a level
        // Then changes door to white, indicating you can proceed
        // Also resets level score for next level
        if (tempScore == 500) 
        {
            liftDoor.GetComponent<MeshRenderer>().material.color = Color.white;
            
            // Loop through all children objects and disable object hit script
            // This allows the player to touch the door without taking damage.
            for (int i = 0; i < this.gameObject.transform.childCount; i++)
            {
                Destroy(this.gameObject.transform.GetChild(i).GetComponent<ObjectHit>());
            }

            levelScore.levelScore = 0;
            levelComplete = true;
        }
    }

    private void OnCollisionEnter(Collision other) {
        if (levelComplete) {
            touchingLift = true;
            Debug.Log("You win!");
            // GameObject.Find("Player (Cappy)").GetComponent<Collider>().enabled = false;
            levelComplete = false;
        }
    }
}
