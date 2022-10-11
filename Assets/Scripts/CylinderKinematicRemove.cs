using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CylinderKinematicRemove : MonoBehaviour
{
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            rb.isKinematic = false;
        }
    }
}
