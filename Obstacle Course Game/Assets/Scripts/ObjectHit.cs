using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    float waitTime = 0.1f;
    Color playerColor = new Color(1f, 0.6428061f, 0f);
    
    public GameObject player;
    public GameObject playerStats;
    private PlayerStats playerLives;
    
    void Start() {
        player = GameObject.Find("Player (Cappy)");
        playerStats = GameObject.Find("Player Stats Container");
        playerLives = playerStats.GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter(Collision other) {
        Debug.Log("Ouch you hit the wall!");
        StartCoroutine(changeColor());
        playerLives.playerLives -= 1;
    }
   
    IEnumerator changeColor() {
        player.GetComponent<MeshRenderer>().material.color = Color.red;
        yield return new WaitForSeconds(waitTime);
        player.GetComponent<MeshRenderer>().material.color = playerColor;
    }
}
