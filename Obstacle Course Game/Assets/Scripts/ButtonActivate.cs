using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonActivate : MonoBehaviour
{
    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {
        door = GameObject.Find("Door");
    }

    private void OnCollisionEnter(Collision other) 
    {
        door.transform.position = new Vector3(1.5f, -0.9f, 4.62f);   
        door.GetComponent<Collider>().enabled = false;     
    }
}
