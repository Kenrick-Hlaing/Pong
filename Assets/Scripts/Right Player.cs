using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RightPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        float verticalValue = Input.GetAxis("Right Paddle");

        Rigidbody rb = GetComponent<Rigidbody>();
        Vector3 force = Vector3.forward * verticalValue * 20;
        
        rb.AddForce(force, ForceMode.Force);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        BoxCollider bc = GetComponent<BoxCollider>();
        Bounds bounds = bc.bounds;
        float maxZ = bounds.max.z;
        float minZ = bounds.min.z;
        float midZ = minZ + 2;
        float collidePoint = collision.transform.position.z;
        // Debug.Log($"We hit {collidePoint} between bounds {maxZ} and {minZ} with middle point {midZ}");
        float degrees = 0f;
        if(collidePoint > midZ){
            degrees = (collidePoint - midZ) * 30f;
        } else if(collidePoint < midZ){
            degrees = (midZ - collidePoint) * -30f;
        }
        // Debug.Log($"degree is {degrees}");
        Quaternion rotation = Quaternion.Euler(0f, degrees, 0f);
        Vector3 bounce = rotation * Vector3.left;

        Rigidbody rb = collision.rigidbody;
        if(rb != null){
            rb.AddForce(bounce * 1000f, ForceMode.Force);
        }
        
    }
}