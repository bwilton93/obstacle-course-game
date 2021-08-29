using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        PrintInstructions();
    }

    // Update is called once per frame
    void Update()
    {
        movePlayer();
    }

    void PrintInstructions()
    {
        Debug.Log("Welcome to the game!");
        Debug.Log("Move the player with the arrow keys or WASD");
        Debug.Log("Try to avoid the walls while you navigate the course!");
        Debug.Log("How about opening the door first?");    
    }

    void movePlayer()
    {
        // Get the horizontal and vertical axis, default bound to arrow keys or WASD.
        // Range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float zTranslation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        
        // Move player based on input
        transform.Translate(xTranslation, 0, zTranslation);        
    }
}
