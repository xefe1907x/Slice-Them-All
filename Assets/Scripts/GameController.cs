using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tapText;
    public GameObject levelCanvas;
    public GameObject effectAndKnife;
    public GameObject settingsPanel;

    public TextMeshProUGUI levelText;

    int gameLevel = 1;

    void Update()
    {
        LevelCounter();
        TapTextDisabler();
    }

    void LevelCounter()
    {
        //Counts level, and writes it to level text
        levelText.text = "Level: " + gameLevel;
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

        if (levelCanvas != null)
        {
            if (levelCanvas.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    levelCanvas.SetActive(false);
                }
            }
        }
        
        if (effectAndKnife != null)
        {
            if (effectAndKnife.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    effectAndKnife.SetActive(false);
                }
            }
        }
        
        if (settingsPanel != null)
        {
            if (settingsPanel.activeInHierarchy)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    settingsPanel.SetActive(false);
                }
            }
        }
    }
}
