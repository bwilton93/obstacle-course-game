using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject door;
    public GameObject window;
    public GameObject player;
    private Scoring playerScore;
    public bool windowLockedOpen = false;

    // Start is called before the first frame update
    void Start() {

    }

    private void OnTriggerEnter(Collider other) {
        if (this.name == "Door Button") {
            door = GameObject.Find("Door");   
            // Open door and disable door collider so player can move through without losing lives
            door.transform.position = new Vector3(1.5f, -0.9f, 4.62f);   
            door.GetComponent<Collider>().enabled = false; 

            // Turn off switch trigger to prevent repeat scoring
            GetComponent<Collider>().isTrigger = false;
        }

        if (this.name == "Window Button") {
            window = GameObject.Find("Window");

            window.transform.position = new Vector3(window.transform.position.x, 0f, window.transform.position.z);
        }
    }

    private void OnTriggerExit(Collider other) {
        if (this.name == "Window Button") {
            if (!windowLockedOpen) {
                window.transform.position = new Vector3(window.transform.position.x, 1f, window.transform.position.z);
            }
        }
    }
}
