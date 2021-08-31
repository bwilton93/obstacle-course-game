using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public Rigidbody projectile;

    public void spawnProjectile() {
        Rigidbody clone;
        clone = Instantiate(projectile, new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation);

        clone.velocity = transform.TransformDirection(Vector3.right * 3f);
    }
}
