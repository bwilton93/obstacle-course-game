using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] public int currentLevel = 0;
    [SerializeField] public int playerLives = 3;
    [SerializeField] public int levelScore = 0;
    [SerializeField] public int totalScore = 0;

    void Update() {
        if (SceneManager.GetActiveScene().buildIndex == currentLevel) {
            StartCoroutine(GameObject.Find("Canvas").GetComponent<FadeToBlack>().FadeBlackOutSquare(false));
        }
    }
}