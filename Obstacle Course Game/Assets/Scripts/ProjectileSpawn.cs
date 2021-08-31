using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpawn : MonoBehaviour
{
    public Rigidbody projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnProjectile() {
        Rigidbody clone;
        clone = Instantiate(projectile, new Vector3(transform.position.x, 1.25f, transform.position.z), transform.rotation);

        clone.velocity = transform.TransformDirection(Vector3.right * 3f);
    }
}
