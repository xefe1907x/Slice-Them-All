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

    public static int wallet = 9999999; // TODO: Make 0 at the beginning

    public static bool isGameStarted;

    void Start()
    {
        wallet = PlayerPrefs.GetInt("playerWallet");
        Physics.gravity = new Vector3(0, -20f, 0);
    }
    
    void Update()
    {
        WalletText();
        LevelCounter();
        TapTextDisabler();
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
        if (isGameStarted)
        {
            if (tapText != null)
            {
                if (tapText.activeInHierarchy)
                {
                    tapText.SetActive(false);
                }
            }

            if (levelCanvas != null)
            {
                if (levelCanvas.activeInHierarchy)
                {
                    levelCanvas.SetActive(false);
                }
            }

            if (effectAndKnife != null)
            {
                if (effectAndKnife.activeInHierarchy)
                {
                    effectAndKnife.SetActive(false);
                }
            }
        }
    }
    

}
