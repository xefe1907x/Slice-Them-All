using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButonSessions : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public GameObject settingsPanel;
    public GameObject boughtKnife2;
    public GameObject notBoughtKnife2;

    AudioSource audioSource;
    public AudioClip clickButton;

    bool didYouBuyFirstKnife = false;
    bool didYouBuySecondKnife = false;
    bool didYouBuyThirdKnife = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
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
        if (!didYouBuyFirstKnife)
        {
            if (GameController.wallet >= CostController.cost2)
            {
                notBoughtKnife2.SetActive(false);
                boughtKnife2.SetActive(true);
            }
        }
    }

    public void TapToFly()
    {
        
    }
}
