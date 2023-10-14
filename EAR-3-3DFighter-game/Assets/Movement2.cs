using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2 : MonoBehaviour
{
    public float speed = 8.0f;
    Rigidbody rb;
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    
    void FixedUpdate()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(hInput,0 ,vInput).normalized;

        if (movement == Vector3.zero)
        {
            return;
        }

        transform.rotation =Quaternion.LookRotation(movement);

        rb.MovePosition(rb.position + movement * speed *Time.fixedDeltaTime);
    }
}
