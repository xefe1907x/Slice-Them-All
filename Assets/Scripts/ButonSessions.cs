using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Audio;

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
    GameObject _blade;

    AudioSource audioSource;
    public AudioClip clickButton;
    public AudioClip buyButton;
    
    bool isFirstClick;

    [SerializeField] float thrustPower = 10085f;
		
    Rigidbody rb;
    
    int isBoughtKnife2; // 0 = false, 1 = true
    int isBoughtKnife3; // 0 = false, 1 = true
    int isBoughtKnife4; // 0 = false, 1 = true

    void Start()
    {
        isBoughtKnife2 = PlayerPrefs.GetInt("isBoughtKnife2");
        isBoughtKnife3 = PlayerPrefs.GetInt("isBoughtKnife3");
        isBoughtKnife4 = PlayerPrefs.GetInt("isBoughtKnife4");
        DOTween.Init();
        audioSource = GetComponent<AudioSource>();
        BuyButtonController();
    }

    void Update()
    {
        FindBladeandRB();
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
    }

    void FindBladeandRB()
    {
        if (_blade == null)
        {
            _blade = GameObject.FindWithTag("Blade");

            if (_blade)
            {
                if (rb == null)
                {
                    rb = _blade.GetComponent<Rigidbody>();
                }
            }
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
        // Move Blade
        if (rb != null)
        {
            if (rb.isKinematic)
                rb.isKinematic = false;

            rb.AddForce(Vector3.up * thrustPower);
            rb.AddForce(Vector3.right * (thrustPower/5.8f));
        }

        // Rotate Blade
        if (!isFirstClick)
        {
            _blade.transform.DORotate(new Vector3(260f, 0, 0), 0.65f, RotateMode.LocalAxisAdd);
            isFirstClick = true;
        }

        else
        {
            _blade.transform.DORotate(new Vector3(360, 0, 0), 1f, RotateMode.LocalAxisAdd);
        }

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
}
