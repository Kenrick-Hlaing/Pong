using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Power : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log($"Hit: ${gameObject.name}");
        if(gameObject.name == "Speed Up")
        {
            Rigidbody otherRigidbody = collision.GetComponent<Rigidbody>();
            otherRigidbody.velocity *= 2f;
        }

        if(gameObject.name == "Teleport")
        {
            collision.transform.position = new Vector3(Random.Range(-7f, 7f), collision.transform.position.y, Random.Range(-4f, 4f));
        }

        transform.position = new Vector3(Random.Range(-7f, 7f), transform.position.y, Random.Range(-4f, 4f));
    }
}
