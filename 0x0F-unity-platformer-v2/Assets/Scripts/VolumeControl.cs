using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;


public class VolumeControl : MonoBehaviour
{
    public AudioMixer master;
    public Slider musicSlider;
    public Slider sfxSlider;

    void Awake ()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        sfxSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        master.SetFloat("sfxVol", musicSlider.value);
        master.SetFloat("musicVol", sfxSlider.value);
    }
    public void SetMusicVolume (float musicLvL)
    {
        master.SetFloat("musicVol", musicLvL);
        PlayerPrefs.SetFloat("musicVolume", musicLvL);
    }

    public void SetFxVolume (float sfxLvL)
    {
        master.SetFloat("sfxVol", sfxLvL);
        PlayerPrefs.SetFloat("sfxVolume", sfxLvL);
    }
}