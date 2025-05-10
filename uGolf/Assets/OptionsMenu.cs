using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

using System.Collections;
using System.Collections.Generic;

public class OptionsMenu : MonoBehaviour
{

    public Slider masterSlider;
    public Slider SFXSlider;
    public Slider musicSlider;
    public AudioMixer mixer;
    public AudioSource SFXAudioSource;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    public void SetMasterVolume(){
        SetVolume("MasterVolume", masterSlider.value);
    }

    public void SetMusicVolume(){
        SetVolume("MusicVolume", musicSlider.value);
    }

    public void SetSFXVolume(){
        SetVolume("SFXVolume", SFXSlider.value);
    }


    void SetVolume(string groupName, float value){
        float adjustedValue = Mathf.Log10(value) * 20f;
        if(value == 0){
            adjustedValue = -80f;
        }

        mixer.SetFloat(groupName, adjustedValue);
    }

    public void ButtonClicked(AudioClip clip){
        SFXAudioSource.PlayOneShot(clip);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetFullscreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }
}
