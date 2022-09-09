using UnityEngine;

public class BuyBarKnifeMovement : MonoBehaviour
{
    float mainPositionx;
    float moveX = 80f;
    bool canGoRight;
    bool canGoLeft;

    void Start()
    {
        canGoRight = true;
        mainPositionx = transform.position.x;
        InvokeRepeating(nameof(MoveKnife),3f,5f);
        Debug.Log(transform.position.x);
    }

    void MoveKnife()
    {
        //Start: 129.57
        //End: 184.86

        if (canGoRight)
        {
            if (transform.position.x <= 184.86f)
            {
                transform.position = new Vector3(transform.position.x + moveX * Time.deltaTime, transform.position.y,
                    transform.position.z);

                if (transform.position.x >= 184.86f)
                {
                    canGoRight = false;
                    canGoLeft = true;
                }
            }
        }
        
        else
        {
            if (transform.position.x >= 129.57f)
            {
                transform.position = new Vector3(transform.position.x - moveX * Time.deltaTime, transform.position.y,
                    transform.position.z);
            }
            
            if (transform.position.x <= 129.57f)
            {
                canGoRight = true;
            }
        }
    }
}
