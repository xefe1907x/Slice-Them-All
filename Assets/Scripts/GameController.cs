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
    public TextMeshProUGUI walletText;

    int gameLevel = 1;

    public static int wallet = 100000; // TODO: Playprefs'e ata.

    void Update()
    {
        WalletText();
        LevelCounter();
        // TapTextDisabler(); TODO: Butona tıklasan da dönmek için tıklamışsın gibi siliyo her şeyi, düzenle
    }

    void WalletText()
    {
        walletText.text = wallet.ToString();
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
    }
}
