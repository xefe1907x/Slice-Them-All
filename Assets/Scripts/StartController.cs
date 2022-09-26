using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartController : MonoBehaviour
{
    public Slider _slider;

    void Update()
    {
        SliderController();
        StartGame();
    }

    void StartGame()
    {
        if (_slider.value >= 3)
        {
            if (PlayerPrefs.GetInt("gameLevel") == 0)
            {
                SceneManager.LoadScene(1);
            }

            else
            {
                int currentLevel = PlayerPrefs.GetInt("gameLevel");
                SceneManager.LoadScene(currentLevel);
            }
        }
    }

    void SliderController()
    {
        _slider.value += Time.deltaTime;
    }
}
