using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    private bool doorOpen = false;
    public GameObject door;
    public GameObject projectileEmitter;
    public GameObject player;
    private Scoring playerScore;
    public bool windowLockedOpen = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Switch triggered");

        if (this.name == "Door Button") {
            if (doorOpen == false) {
                door = GameObject.Find("Door");   
                // Open door and disable door collider so player can move through without losing lives
                door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z);   
                door.GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false; 

                // Turn off switch trigger to prevent repeat scoring
                GetComponent<Collider>().isTrigger = false;

                doorOpen = true;
            }

            if (doorOpen == true) {
                StartCoroutine(doorCloseTimer());
            }
        }

        if (this.name == "Projectile Button") {
            projectileEmitter = GameObject.Find("Projectile Emitter");

            projectileEmitter.GetComponent<ProjectileSpawn>().spawnProjectile();

            GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().isTrigger = false;

            StartCoroutine(buttonDisabledTimer());
        }
    }

    IEnumerator doorCloseTimer() {
        yield return new WaitForSeconds(3);
        door.transform.position = new Vector3(door.transform.position.x, 0.9f, door.transform.position.z); 
        doorOpen = false;
        door.GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().isTrigger = true; 
    }

    IEnumerator buttonDisabledTimer() {
        yield return new WaitForSeconds(5);
        GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().isTrigger = true;
    }
}
