using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonSessions : MonoBehaviour
{
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
}
