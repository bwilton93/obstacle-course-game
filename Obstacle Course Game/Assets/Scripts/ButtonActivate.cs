using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject door;
    public GameObject projectileEmitter;
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
            door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z);   
            door.GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().enabled = false; 

            // Turn off switch trigger to prevent repeat scoring
            GetComponent<Collider>().isTrigger = false;
        }

        if (this.name == "Window Button") {
            projectileEmitter = GameObject.Find("Projectile Emitter");

            projectileEmitter.GetComponent<ProjectileSpawn>().spawnProjectile();
        }
    }

    // private void OnTriggerExit(Collider other) {
    //     if (this.name == "Window Button") {
    //         if (!windowLockedOpen) {
    //             window.transform.position = new Vector3(window.transform.position.x, 1f, window.transform.position.z);
    //         }
    //     }
    // }
}
