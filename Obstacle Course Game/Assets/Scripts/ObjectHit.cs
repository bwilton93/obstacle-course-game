using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectHit : MonoBehaviour
{
    public GameObject player;
    
    float waitTime = 0.1f;

    Color playerColor = new Color(1f, 0.6428061f, 0f);

    void Start() 
    {
        player = GameObject.Find("Player (Cappy)");
    }

    private void OnCollisionEnter(Collision other) 
    {
        Debug.Log("Ouch you hit the wall!");
        StartCoroutine(changeColor());
    }
   
    IEnumerator changeColor() 
    {
        // timePassed = 0;
        player.GetComponent<MeshRenderer>().material.color = Color.red;

        yield return new WaitForSeconds(waitTime);

        player.GetComponent<MeshRenderer>().material.color = playerColor;
    }
}
