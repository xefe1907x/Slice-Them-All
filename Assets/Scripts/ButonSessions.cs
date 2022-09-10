using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ButonSessions : MonoBehaviour
{
    public AudioMixer audioMixer;
    
    public GameObject settingsPanel;

    AudioSource audioSource;
    public AudioClip clickButton;

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
}
