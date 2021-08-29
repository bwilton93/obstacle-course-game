using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float playerSpeed = 5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Get the horizontal and vertical axis, default bound to arrow keys or WASDs.
        // Range -1 to 1
        float xTranslation = Input.GetAxis("Horizontal") * playerSpeed * Time.deltaTime;
        float zTranslation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        
        // Move player based on input
        transform.Translate(xTranslation, 0, zTranslation);        
    }
}
