using System.Collections;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class ButonSessions : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public GameObject settingsPanel;
    public GameObject boughtKnife2;
    public GameObject notBoughtKnife2;
    public GameObject boughtKnife3;
    public GameObject notBoughtKnife3;
    public GameObject boughtKnife4;
    public GameObject notBoughtKnife4;
    public GameObject boughtTrail2;
    public GameObject notBoughtTrail2;
    public GameObject boughtTrail3;
    public GameObject notBoughtTrail3;
    public GameObject boughtTrail4;
    public GameObject notBoughtTrail4;
    public GameObject tapToFlyButton;
    GameObject _blade;

    AudioSource audioSource;
    public AudioClip clickButton;
    public AudioClip buyButton;
    public AudioClip mainTheme;
    public AudioClip flipVoice;
    public AudioClip sliceVoice;
    public AudioClip cannotSlice;

    public Sequence bladeDotweenSequence;
    
    bool isFirstClick = true;
    public static bool isTapToFlyDisabled;
    public static bool objectSliced;
    public static bool fallOnStun;

    
    
    int isBoughtKnife2; // 0 = false, 1 = true
    int isBoughtKnife3; // 0 = false, 1 = true
    int isBoughtKnife4; // 0 = false, 1 = true

    int isBoughtTrail2; // 0 = false, 1 = true
    int isBoughtTrail3; // 0 = false, 1 = true
    int isBoughtTrail4; // 0 = false, 1 = true

    void Start()
    {
        isTapToFlyDisabled = false;
        isBoughtKnife2 = PlayerPrefs.GetInt("isBoughtKnife2");
        isBoughtKnife3 = PlayerPrefs.GetInt("isBoughtKnife3");
        isBoughtKnife4 = PlayerPrefs.GetInt("isBoughtKnife4");
        isBoughtTrail2 = PlayerPrefs.GetInt("isBoughtTrail2");
        isBoughtTrail3 = PlayerPrefs.GetInt("isBoughtTrail3");
        isBoughtTrail4 = PlayerPrefs.GetInt("isBoughtTrail4");
        DOTween.Init();
        bladeDotweenSequence = DOTween.Sequence();
        audioSource = GetComponent<AudioSource>();
        BuyButtonController();
        audioSource.PlayOneShot(mainTheme);
    }

    void Update()
    {
        FindBladeandRB();
        DisableTapToFlyButton();
        VoiceofSlice();
        VoiceofStuns();
    }

    void VoiceofSlice()
    {
        if (objectSliced)
        {
            audioSource.PlayOneShot(sliceVoice);
            objectSliced = false;
        }
    }

    void VoiceofStuns()
    {
        if (fallOnStun)
        {
            audioSource.PlayOneShot(cannotSlice);
            fallOnStun = false;
        }
    }

    void DisableTapToFlyButton()
    {
        if (isTapToFlyDisabled)
        {
            tapToFlyButton.SetActive(false);
            isTapToFlyDisabled = false;
        }
    }

    void BuyButtonController()
    {
        if (isBoughtKnife2 == 1)
        {
            notBoughtKnife2.SetActive(false);
            boughtKnife2.SetActive(true);
        }

        if (isBoughtKnife3 == 1)
        {
            notBoughtKnife3.SetActive(false);
            boughtKnife3.SetActive(true);
        }
        
        if (isBoughtKnife4 == 1)
        {
            notBoughtKnife4.SetActive(false);
            boughtKnife4.SetActive(true);
        }
        
        if (isBoughtTrail2 == 1)
        {
            notBoughtTrail2.SetActive(false);
            boughtTrail2.SetActive(true);
        }

        if (isBoughtTrail3 == 1)
        {
            notBoughtTrail3.SetActive(false);
            boughtTrail3.SetActive(true);
        }
        
        if (isBoughtTrail4 == 1)
        {
            notBoughtTrail4.SetActive(false);
            boughtTrail4.SetActive(true);
        }
    }

    void FindBladeandRB()
    {
        if (_blade == null)
        {
            _blade = GameObject.FindWithTag("Blade");
        }
    }

    public void SettingsButton()
    {
        audioSource.PlayOneShot(clickButton);
        settingsPanel.SetActive(true);
    }

    public void SettingsButtonClose()
    {
        audioSource.PlayOneShot(clickButton);
        settingsPanel.SetActive(false);
    }

    public void OpenVolume()
    {
        audioMixer.SetFloat("volume", 0);
    }
    
    public void CloseVolume()
    {
        audioMixer.SetFloat("volume", -80);
    }

    public void BuyKnife2()
    {
        if (GameController.wallet >= CostController.cost2)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtKnife2.SetActive(false);
            boughtKnife2.SetActive(true);
            GameController.wallet -= CostController.cost2;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtKnife2", 1);
        }
    }
    
    public void TapToFly()
    {
        if(!_blade)
            return;

        audioSource.PlayOneShot(flipVoice);
        KnifeSpinMechanic.isTapToFlyActive = false;

        if (!GameController.isGameStarted)
        {
            GameController.isGameStarted = true;
        }
        
    }

    public void UseKnife1()
    {
        audioSource.PlayOneShot(clickButton);
        GameObject _knife = GameObject.FindWithTag("Blade");
        
        KnifePool.knifeNumber = 0;
        PlayerPrefs.SetInt("knifeNumber", 0);

        Destroy(_knife);

        KnifePool.isknifeInstantiated = false;
        KnifeBar.isBarInstantiated = true;
        KnifeBar.isBarReset = true;
    }

    public void UseKnife2()
    {
        audioSource.PlayOneShot(clickButton);
        GameObject _knife = GameObject.FindWithTag("Blade");
        
        KnifePool.knifeNumber = 1;
        PlayerPrefs.SetInt("knifeNumber", 1);

        Destroy(_knife);

        KnifePool.isknifeInstantiated = false;
        KnifeBar.isBarInstantiated = true;
        KnifeBar.isBarReset = true;
    }

    public void BuyKnife3()
    {
        if (GameController.wallet >= CostController.cost3)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtKnife3.SetActive(false);
            boughtKnife3.SetActive(true);
            GameController.wallet -= CostController.cost3;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtKnife3", 1);
        }
    }
    
    public void UseKnife3()
    {
        audioSource.PlayOneShot(clickButton);
        GameObject _knife = GameObject.FindWithTag("Blade");
        
        KnifePool.knifeNumber = 2;
        PlayerPrefs.SetInt("knifeNumber", 2);

        Destroy(_knife);

        KnifePool.isknifeInstantiated = false;
        KnifeBar.isBarInstantiated = true;
        KnifeBar.isBarReset = true;
    }
    
    public void BuyKnife4()
    {
        if (GameController.wallet >= CostController.cost4)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtKnife4.SetActive(false);
            boughtKnife4.SetActive(true);
            GameController.wallet -= CostController.cost4;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtKnife4", 1);
        }
    }
    
    public void UseKnife4()
    {
        audioSource.PlayOneShot(clickButton);
        GameObject _knife = GameObject.FindWithTag("Blade");
        
        KnifePool.knifeNumber = 3;
        PlayerPrefs.SetInt("knifeNumber", 3);

        Destroy(_knife);

        KnifePool.isknifeInstantiated = false;
        KnifeBar.isBarInstantiated = true;
        KnifeBar.isBarReset = true;
    }

    public void ButtonClickSound()
    {
        audioSource.PlayOneShot(clickButton);
    }
    
    public void UseTrail1()
    {
        audioSource.PlayOneShot(clickButton);
        
        PlayerPrefs.SetInt("trailNumber", 0);

        Knife_1_Trails.isTrailActivated = false;
        TrailBar.isTrailInstantiated = true;
        TrailBar.isTrailReset = true;
    }
    
    public void BuyTrail2()
    {
        if (GameController.wallet >= CostController.cost6)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtTrail2.SetActive(false);
            boughtTrail2.SetActive(true);
            GameController.wallet -= CostController.cost6;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtTrail2", 1);
        }
    }
    
    public void UseTrail2()
    {
        audioSource.PlayOneShot(clickButton);
        
        PlayerPrefs.SetInt("trailNumber", 1);

        Knife_1_Trails.isTrailActivated = false;
        TrailBar.isTrailInstantiated = true;
        TrailBar.isTrailReset = true;
    }
    
    public void BuyTrail3()
    {
        if (GameController.wallet >= CostController.cost7)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtTrail3.SetActive(false);
            boughtTrail3.SetActive(true);
            GameController.wallet -= CostController.cost7;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtTrail3", 1);
        }
    }
    
    public void UseTrail3()
    {
        audioSource.PlayOneShot(clickButton);
        
        PlayerPrefs.SetInt("trailNumber", 2);

        Knife_1_Trails.isTrailActivated = false;
        TrailBar.isTrailInstantiated = true;
        TrailBar.isTrailReset = true;
    }
    
    public void BuyTrail4()
    {
        if (GameController.wallet >= CostController.cost8)
        {
            audioSource.PlayOneShot(buyButton);
            notBoughtTrail4.SetActive(false);
            boughtTrail4.SetActive(true);
            GameController.wallet -= CostController.cost8;
            PlayerPrefs.SetInt("playerWallet", GameController.wallet);
            PlayerPrefs.SetInt("isBoughtTrail4", 1);
        }
    }
    
    public void UseTrail4()
    {
        audioSource.PlayOneShot(clickButton);
        
        PlayerPrefs.SetInt("trailNumber", 3);

        Knife_1_Trails.isTrailActivated = false;
        TrailBar.isTrailInstantiated = true;
        TrailBar.isTrailReset = true;
    }

    public void NextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;
        Time.timeScale = 1;
        GameController.gameLevel += 1;
        PlayerPrefs.SetInt("gameLevel", GameController.gameLevel);
        GameController.wallet += GameController.gamePoints;
        PlayerPrefs.SetInt("playerWallet", GameController.wallet);
        KnifeSpinMechanic.isTapToFlyActive = true;
        
        // Yeni bölümler eklersen bu alttaki if else kısmını tamamen sil, sadece else'nin içindekini Next Level methodunun içinde tut
        if (currentScene >= 5)
        {
            SceneManager.LoadScene(1);
            GameController.gameLevel = 1;
            PlayerPrefs.SetInt("gameLevel", GameController.gameLevel);
        }
        else
        {
            SceneManager.LoadScene(nextScene);
        }
    }
}
