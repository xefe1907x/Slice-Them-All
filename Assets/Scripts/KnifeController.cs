using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class KnifeController : MonoBehaviour
{
    Rigidbody rb;

    [SerializeField] float jumpForce = 9000000f;
    [SerializeField] float rightForce = 70000f;
    float rotateX;

    bool isKnifeFlipping;
    bool isRotateOK = true;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        DOTween.Init();
    }

    void Update()
    {
        JumpKnife();
        FlipKnife();
    }

    void JumpKnife()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isRotateOK)
                isRotateOK = true;
            if (!isKnifeFlipping)
                isKnifeFlipping = true;
            if (rb.isKinematic)
                rb.isKinematic = false;
            rb.AddForce(Vector3.up * Time.deltaTime * jumpForce);
            rb.AddForce(Vector3.right * Time.deltaTime * rightForce);
        }
    }

    void FlipKnife()
    {
        if (isKnifeFlipping)
        {
            if (isRotateOK)
                rotateX = 10000f;
            
            transform.DORotate(new Vector3 (transform.rotation.x + rotateX * Time.deltaTime, -0.309f, 0.636f), 0.3f, RotateMode.LocalAxisAdd);
            KnifeStopper();
        }
    }
    void KnifeStopper()
    {
        if (isKnifeFlipping)
            Invoke(nameof(RotateStoper),0.1f);
        
        if (rotateX > 5000)
        {
            rotateX -= 10000 * Time.deltaTime;
        }

        else
        {
            // 0.0983 - 0.16
            if (transform.rotation.x >= 0.0983f & transform.rotation.x <= 0.16f)
            {
                rotateX = 0;
                isKnifeFlipping = false;
            }
        }
    }

    void RotateStoper()
    {
        if (isRotateOK)
            isRotateOK = false;
    }
}
