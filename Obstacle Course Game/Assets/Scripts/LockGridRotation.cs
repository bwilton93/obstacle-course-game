using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockGridRotation : MonoBehaviour
{
    public Transform target;

    // Update is called once per frame
    void Update()
    {
        if(target != null) {
            Vector3 targetPosition = new Vector3(target.position.x, this.transform.position.y, target.position.z);

            transform.LookAt(targetPosition);
        }
    }
}
