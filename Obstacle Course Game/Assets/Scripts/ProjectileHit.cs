using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileHit : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag != "Projectile Switch") {
            Destroy(this.gameObject);
        }
    }
}
