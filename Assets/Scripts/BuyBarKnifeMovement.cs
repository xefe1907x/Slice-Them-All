using System;
using DG.Tweening;
using UnityEngine;

public class BuyBarKnifeMovement : MonoBehaviour
{
    float mainPositionx;
    float moveX = 250f;
    float timeForKnife;
    
    bool canGoRight;
    bool canTurnRight;
    bool timeResetter;

    void Start()
    {
        DOTween.Init();
        canGoRight = true;
        canTurnRight = true;
        timeForKnife = 0;
        mainPositionx = transform.position.x;
    }

    void Update()
    {
        MoveKnife();
    }

    void MoveKnife()
    {
        //transform.position
        //Start: 129.57
        //End: 184.86
        
        timeForKnife += Time.deltaTime;
        
        if (canGoRight & timeForKnife >= 3f)
        {
            if (transform.position.x <= 184.86f)
            {
                transform.position = new Vector3(transform.position.x + moveX * Time.deltaTime, transform.position.y,
                    transform.position.z);
            }
            
            if (transform.position.x >= 184.86f)
            {
                TurnKnife();
            }
        }
        
        else
        {
            if (transform.position.x >= mainPositionx)
            {
                transform.position = new Vector3(transform.position.x - moveX * Time.deltaTime, transform.position.y,
                    transform.position.z);
            }
            
            if (transform.position.x <= mainPositionx)
            {
                canGoRight = true;
                canTurnRight = true;
                if (timeResetter)
                {
                    timeForKnife = 0;
                    timeResetter = false;
                }
            }
        }
    }

    void TurnKnife()
    {
        if (canTurnRight & canGoRight)
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, -55), 0.3f);
            
            if (transform.rotation.z >= 0.455f)
            {
                canTurnRight = false;
            }
        }

        else
        {
            transform.DORotate(new Vector3(transform.rotation.x, transform.rotation.y, 0), 0.4f);

            if (transform.rotation.z >= 0)
            {
                canGoRight = false;
                timeResetter = true;
            }
        }
    }
}
