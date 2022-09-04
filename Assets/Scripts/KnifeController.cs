using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float jumpForce = 10000000f;
    [SerializeField] float rightForce = 70000f;
    [SerializeField] float rotateZ = 550f;

    bool isKnifeFlipping;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        JumpKnife();
        Debug.Log(isKnifeFlipping);
    }

    void JumpKnife()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
            // rb.AddForce(Vector3.right * Time.deltaTime * rightForce);
            isKnifeFlipping = true;
            FlipKnife();
        }
    }

    void FlipKnife()
    {
        if (isKnifeFlipping)
        {
            transform.Rotate(transform.rotation.x, transform.rotation.y,
                transform.rotation.z - rotateZ * Time.deltaTime);
            StartCoroutine(nameof(KnifeStopper));
        }
    }

    IEnumerator KnifeStopper()
    {
        yield return new WaitForSeconds(3f);
        isKnifeFlipping = false;
    }
}
