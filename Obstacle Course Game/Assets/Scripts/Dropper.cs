using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    public GameObject[] obstacles;
    
    public float waitTime = f;
    public float dropTime;

    private int obstacleChild = 0;

    public bool timerStarted;
    public bool levelReset;

    private bool timeInitialised = false;

    // Update is called once per frame
    void Update()
    {
        if(timerStarted) {
            if(!timeInitialised) {
                dropTime = Time.time + waitTime;
                timeInitialised = true;
            }

            if(Time.time > dropTime) {
                obstacles[obstacleChild].GetComponent<Rigidbody>().useGravity = true;
                dropTime += waitTime;
                obstacleChild++;

                // This prevents obstacleChild number from becoming larger than array size
                if(obstacleChild == obstacles.Length) {
                    timerStarted = false;
                }
            }
        }

        if(levelReset) {
            foreach(Transform child in transform) {
                child.GetComponent<Rigidbody>().useGravity = false;
                obstacleChild = 0;
                levelReset = false;
                timerStarted = false;
            }
        }
    }
}
