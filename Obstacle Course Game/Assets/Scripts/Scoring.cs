using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public GameObject player;
    public PlayerStats playerScore;

    void Start() {
        player = GameObject.Find("Player (Cappy)");
        playerScore = GameObject.Find("Player Stats Container").GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter(Collision other) {
        playerScore.levelScore += 100;
        playerScore.totalScore += 100;

        Destroy(gameObject);    
    }
}
