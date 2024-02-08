using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.name == "Ball"){
            Vector3 collisionForce = collision.relativeVelocity;
            Vector3 collisionNormal = collision.contacts[0].normal;
            Vector3 newVelocity = Vector3.Reflect(collisionForce, collisionNormal);
            Rigidbody rb = collision.rigidbody;
            if(rb != null){
                rb.velocity = newVelocity;
            }
        }
    }
}
