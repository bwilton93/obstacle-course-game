using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class FadeToBlack : MonoBehaviour
{
    public GameObject blackOutSquare;
    public GameObject player;
    public GameObject playerStats;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    void start() {
    }

    // Update is called once per frame
    void Update()
    {
        playerStats = GameObject.Find("Player Stats Container");
        player = GameObject.Find("Player (Cappy)");

        if (player.GetComponent<PlayerController>().moveToLift) {
            StartCoroutine(FadeBlackOutSquare(true)); 
        }

        if (SceneManager.GetActiveScene().buildIndex == playerStats.GetComponent<PlayerStats>().currentLevel) {
            StartCoroutine(FadeBlackOutSquare(false));
        }
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack, int fadeSpeed = 2) {
        Color objectColor = blackOutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if (fadeToBlack) {
            player.GetComponent<PlayerController>().movementLocked = true;
            while (blackOutSquare.GetComponent<Image>().color.a < 1) {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                fadeToBlack = false;
                yield return null;
            }
        } else {
            while (blackOutSquare.GetComponent<Image>().color.a > 0) {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackOutSquare.GetComponent<Image>().color = objectColor;
                fadeToBlack = true;
                player.GetComponent<PlayerController>().movementLocked = false;
                yield return null;
            }
        }
    }
}
