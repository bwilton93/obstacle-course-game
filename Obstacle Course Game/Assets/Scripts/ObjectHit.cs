using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    float waitTime = 0.1f;
    Color playerColor = new Color(1f, 0.6428061f, 0f);
    
    public bool doorLockedOpen;
    public GameObject player;
    public GameObject playerStats;
    public GameObject door;
    public GameObject door2;
    private PlayerStats playerLives;
    
    void Start() {
        player = GameObject.Find("Player (Cappy)");
        playerStats = GameObject.Find("Player Stats Container");
        playerLives = playerStats.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other) {
        switch (gameObject.tag) {
            case "Projectile Switch":
                door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z); 
                door.GetComponent<Collider>().enabled = false;

                if (door2 != null) {
                    door2.transform.position = new Vector3(door2.transform.position.x, -0.9f, door2.transform.position.z); 
                    door2.GetComponent<Collider>().enabled = false;
                }

                // Changes door lock switch to indicate door is now open
                GetComponent<MeshRenderer>().material.color = new Vector4(0.4245283f, 0f, 0f, 1f);

                doorLockedOpen = true;

                Destroy(other.gameObject);
                break;

            case "Obstacle":
                if (other.gameObject == GameObject.Find("Player (Cappy)")) {
                    Debug.Log("Obstacle hit");
                    StartCoroutine(changeColor());
                    playerLives.playerLives -= 1;
                    player.GetComponent<PlayerController>().resetLevel();
                } 
                break;
        }
    }
   
    IEnumerator changeColor() {
        player.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<MeshRenderer>().material.color = playerColor;
    }
}
