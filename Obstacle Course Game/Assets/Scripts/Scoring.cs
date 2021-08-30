using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoring : MonoBehaviour
{
    public PlayerStats playerScore;

    void Start() {
        playerScore = GameObject.Find("Player (Cappy)").GetComponent<PlayerStats>();
    }

    private void OnCollisionEnter(Collision other) {
        playerScore.levelScore += 100;
        playerScore.totalScore += 100;

        Destroy(gameObject);    
    }
}
