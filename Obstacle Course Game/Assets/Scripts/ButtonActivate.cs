using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject door;
    public GameObject player;
    private Scoring playerScore;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
        playerScore = GameObject.Find("Player (Cappy)").GetComponent<Scoring>();
    }

    private void OnCollisionEnter(Collision other) 
    {
        // Open door and disable door collider so player can move through without losing lives
        door.transform.position = new Vector3(1.5f, -0.9f, 4.62f);   
        door.GetComponent<Collider>().enabled = false; 

        // Turn off switch collider to prevent repeat scoring
        GetComponent<Collider>().enabled = false;

        playerScore.playerScore += 100;    
    }
}
