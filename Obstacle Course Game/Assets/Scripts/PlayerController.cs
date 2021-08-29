using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;
    [SerializeField] float rotationSpeed = 20f;

    public GameObject camera;

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
        float horizontalTranslation = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float verticalTranslation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        
        // This gets the camera angle and determines movement direction based on the result
        Vector3 input = Quaternion.Euler (0, camera.transform.eulerAngles.y, 0) * new Vector3(horizontalTranslation, 0.0f, verticalTranslation);

        transform.position += input;

        // This make the bean man rotate in the direction he is walking.
        // It only sets a rotation when there is an input
        // This prevents the character rotation from resetting to 0,0,0 when keys are released
        if ((horizontalTranslation != 0 || verticalTranslation != 0)) 
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(input), Time.deltaTime * rotationSpeed);
        }
    }
}
