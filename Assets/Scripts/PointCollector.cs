using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class PointCollector : MonoBehaviour
{
    GameObject _blade;
    Rigidbody rb;
    void Update()
    {
        FindBlade();
    }

    void FindBlade()
    {
        if (!_blade)
        {
            _blade = GameObject.FindWithTag("Blade");
            rb = _blade.GetComponent<Rigidbody>();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Sliceable"))
        {
            GameController.gamePoints += 1;
            ButonSessions.objectSliced = true;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish2x"))
        {
            GameController.gamePoints *= 2;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish50x"))
        {
            GameController.gamePoints *= 50;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish10x"))
        {
            GameController.gamePoints *= 10;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish3x"))
        {
            GameController.gamePoints *= 3;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish6x"))
        {
            GameController.gamePoints *= 6;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("Finish4x"))
        {
            GameController.gamePoints *= 4;
            StartCoroutine(nameof(OnFinishCoroutine));
        }
        
        if (other.gameObject.CompareTag("cannotSlice"))
        {
            ButonSessions.fallOnStun = true;
        }
    }

    private IEnumerator OnFinishCoroutine()
    {
        GameController.isYouWinPanelOpen = true;
        yield return new WaitForEndOfFrame();
        Time.timeScale = 0;
    }
}
