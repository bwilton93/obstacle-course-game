using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemMovement : MonoBehaviour
{
    float speed = 3;
    float height = 0.05f;
    float rotateSpeed = 0.2f;

    Vector3 pos;

    void Start() {
        // Get gem current position
        pos = transform.position;
    }

    // Update is called once per frame
    void Update() {
        moveGem();
    }

    private void moveGem() {
        // Calculate new Y (height) position
        float newY = Mathf.Sin(Time.time * speed) * height + pos.y;
        // Set the object's height to the new calculated Y value
        transform.position = new Vector3(pos.x, newY, pos.z);
        transform.Rotate(0, rotateSpeed, 0, Space.Self);
    }
}
