using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 0.01f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis, default bound to arrow keys.
        // Range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * playerSpeed;
        float zTranslation = Input.GetAxis("Vertical") * playerSpeed;
        
        // Move player based on input
        transform.Translate(xTranslation, 0, zTranslation);        
    }
}
