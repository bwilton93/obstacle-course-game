using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Button startButton;

    // Start is called before the first frame update
    void Start()
    {
        Button btn = startButton.GetComponent<Button>();
        btn.onClick.AddListener(StartGameOnClick);

        Debug.Log(SceneManager.sceneCountInBuildSettings);
    }

    void StartGameOnClick() {
        // Update level stats in player stats object
        GameObject.Find("Player Stats Container").GetComponent<PlayerStats>().currentLevel = 1;

        // Set level to load and then load level from scene manager
        int levelToLoad = GameObject.Find("Player Stats Container").GetComponent<PlayerStats>().currentLevel;
        SceneManager.LoadScene(levelToLoad);
    }
}
