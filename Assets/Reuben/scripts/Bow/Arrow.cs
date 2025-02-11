using System;
using Unity.VisualScripting;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public Rigidbody rb;

    public LayerMask layerMask;


    void Update()
    {
        pointInMovementDirection();
    }

    void pointInMovementDirection()
    {
        transform.LookAt(transform.position + rb.linearVelocity, Vector3.up);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 3)
        {
            return;
        }
        Debug.Log("Collision with " + collision.gameObject.name);
        rb.constraints = RigidbodyConstraints.FreezeAll; 
    }
}
