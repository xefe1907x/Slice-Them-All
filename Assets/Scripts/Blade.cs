using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        BladeMover();
    }

    void BladeMover()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(Vector3.up * 100);
            rb.AddForce(Vector3.right * 100);
        }
    }
}
