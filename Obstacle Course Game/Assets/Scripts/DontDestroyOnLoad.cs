using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    public void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag(gameObject.tag);
        
        if (objs.Length > 2) {
            Destroy(gameObject);
        } else {
            DontDestroyOnLoad(gameObject);
        }
    }
}
