using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;

    public float smoothSpeed = 0.125f;

    public Vector3 offset;

    // void Start()
    // {
    //     InvokeRepeating(nameof(FindTarget),0,0.25f);
    // }

    void Update()
    {
        FindTarget();
    }

    void LateUpdate()
    {
        if (!target)
        {
            return;
        }
        transform.position = target.position + offset;
    }

    private void FindTarget()
    {
        var targetGameObject = GameObject.FindWithTag("Blade");
        if (targetGameObject)
        {
            target = targetGameObject.transform;
        }
    }
    
    
}
