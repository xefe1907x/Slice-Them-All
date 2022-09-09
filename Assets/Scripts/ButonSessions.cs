using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButonSessions : MonoBehaviour
{
    public GameObject settingsPanel;

    AudioSource audioSource;
    public AudioClip clickButton;
    
    public void SettingsButton()
    {
        audioSource.PlayOneShot(clickButton);
        settingsPanel.SetActive(true);
    }
}
