using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;

public class ScreenSettings : MonoBehaviour
{

    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    Resolution[] resolutions;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        resolutions = Screen.resolutions;
        for(int i = 0; i < resolutions.Length; i++){
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutions[i].ToString()));
        }

        Resolution currentResolution = Screen.currentResolution;

        int currentIndex = PlayerPrefs.GetInt("resolution", -1); 
        if(currentIndex == -1){
            currentIndex = Array.IndexOf(resolutions, currentResolution);
        }

        resolutionDropdown.value = currentIndex;
    }

    public void SetResolution(){
        int currentIndex = resolutionDropdown.value;
        bool isFullscreen = fullscreenToggle.isOn;
        Resolution res = resolutions[currentIndex];

        if(isFullscreen){ //fullscreen ON
            Screen.SetResolution(res.width, res.height, Screen.fullScreen);
        }
        else { //fullscreen OFF
            Screen.SetResolution(res.width, res.height, FullScreenMode.Windowed);
        }
        
        PlayerPrefs.SetInt("resolution", currentIndex);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
