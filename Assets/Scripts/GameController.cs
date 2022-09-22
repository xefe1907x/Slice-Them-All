using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameObject tapText;
    public GameObject levelCanvas;
    public GameObject effectAndKnife;
    public GameObject settingsPanel;
    public GameObject _youWinPanel;

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI walletText;
    public TextMeshProUGUI levelEarning;

    public static int gameLevel = 1;
    public static int wallet;
    public static int gamePoints;

    public static bool isGameStarted;
    public static bool isYouWinPanelOpen;
    public static bool canWeCloseYouWinPanel;

    void Start()
    {
        wallet = PlayerPrefs.GetInt("playerWallet");
        isGameStarted = false;
        gamePoints = 0;
    }
    
    void Update()
    {
        WalletText();
        LevelCounter();
        TapTextDisabler();
        YouWinPanel();
        CloseWinPanel();
    }

    void YouWinPanel()
    {
        levelEarning.text = gamePoints.ToString();

        if (isYouWinPanelOpen)
        {
            _youWinPanel.SetActive(true);
            isYouWinPanelOpen = false;
        }
    }

    void CloseWinPanel()
    {
        if (canWeCloseYouWinPanel)
        {
            _youWinPanel.SetActive(false);
            canWeCloseYouWinPanel = false;
        }
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
