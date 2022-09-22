using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrail2 : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(new Vector3(transform.rotation.x,transform.rotation.y,transform.rotation.z + 1.5f));
    }
}
