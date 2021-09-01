using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    private bool doorOpen = false;
    public GameObject doorLockSwitch;
    public GameObject door;
    public GameObject door2;
    public GameObject projectileEmitter;
    public GameObject player;
    private Scoring playerScore;
    public bool windowLockedOpen = false;

    private void OnTriggerEnter(Collider other) {
        Debug.Log("Switch triggered");

        if (this.name == "Door Button") {
            if (doorOpen == false) {   
                // Open door and disable door collider so player can move through without losing lives
                door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z);   
                door.GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false; 
                door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z);   
                door.GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false; 

                // Turn off switch trigger to prevent repeat scoring
                GetComponent<Collider>().isTrigger = false;

                StartCoroutine(doorCloseTimer(door));
                // doorOpen = true;
            }

            if (door2 != null) {
                door2.transform.position = new Vector3(door2.transform.position.x, -0.9f, door2.transform.position.z);   
                door.GetComponent<Collider>().enabled = false;
                GetComponent<Collider>().enabled = false; 

                StartCoroutine(doorCloseTimer(door2));
            }

            // if (doorOpen == true) {
            // }

        }

        if (this.name == "Projectile Button") {
            Debug.Log("Projectile Switch Triggered");
            projectileEmitter.GetComponent<ProjectileSpawn>().spawnProjectile();

            GetComponent<Collider>().enabled = false;
            GetComponent<Collider>().isTrigger = false;

            StartCoroutine(buttonDisabledTimer());
        }
    }

    IEnumerator doorCloseTimer(GameObject arg) {
        yield return new WaitForSeconds(3);
        if (doorLockSwitch.GetComponent<ObjectHit>().doorLockedOpen == false) {
            arg.transform.position = new Vector3(arg.transform.position.x, 0.9f, arg.transform.position.z); 
            doorOpen = false;
            door.GetComponent<Collider>().enabled = true;
            GetComponent<Collider>().enabled = true;
            GetComponent<Collider>().isTrigger = true; 
        }
    }

    IEnumerator buttonDisabledTimer() {
        yield return new WaitForSeconds(5);
        GetComponent<Collider>().enabled = true;
        GetComponent<Collider>().isTrigger = true;
    }
}
