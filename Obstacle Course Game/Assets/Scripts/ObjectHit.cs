using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    float waitTime = 0.1f;
    Color playerColor = new Color(1f, 0.6428061f, 0f);
    
    public GameObject player;
    public GameObject playerStats;
    public GameObject door;
    private PlayerStats playerLives;
    
    void Start() {
        player = GameObject.Find("Player (Cappy)");
        playerStats = GameObject.Find("Player Stats Container");
        playerLives = playerStats.GetComponent<PlayerStats>();
    }

    private void OnTriggerEnter(Collider other) {
        if (this.name == "Window Lock Switch") {
            door.transform.position = new Vector3(door.transform.position.x, -0.9f, door.transform.position.z); 
            door.GetComponent<Collider>().enabled = false;

            // Changes door lock switch to indicate door is now open
            GetComponent<MeshRenderer>().material.color = new Vector4(0.4245283f, 0f, 0f, 1f);

            Destroy(other.gameObject);
        }

        if (gameObject.tag == "Obstacle" && other.gameObject == GameObject.Find("Player (Cappy)")) {
            StartCoroutine(changeColor());
            playerLives.playerLives -= 1;
            player.GetComponent<PlayerController>().resetLevel();
        }
    }
   
    IEnumerator changeColor() {
        player.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<MeshRenderer>().material.color = playerColor;
    }
}
