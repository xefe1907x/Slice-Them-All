using System.Collections;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tapText;

    void Update()
    {
        TapTextDisabler();
    }

    void TapTextDisabler()
    {
        if (tapText != null)
        {
            if (tapText.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    tapText.SetActive(false);
                }
            }
        }
    }
}
