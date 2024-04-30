using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioUI_Controller : MonoBehaviour
{

    [Header("Volume")]
    public Slider bgmSlider, sfxSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("BGM_Volume"))
        {
            loadVolume();
        }
        else
        {
            BGMvolumeController();
            SFXvolumeController();
        }
    }

    public void BGMvolumeController()
    {
        float bgmVol = bgmSlider.value;
        AudioManager.Instance.BGMVolume(bgmSlider.value);
        PlayerPrefs.SetFloat("BGM_Volume", bgmVol);
    }

    public void SFXvolumeController()
    {
        float sfxVol = sfxSlider.value;
        AudioManager.Instance.SFXVolume(sfxSlider.value);
        PlayerPrefs.SetFloat("SFX_Volume", sfxVol);
    }

    public void loadVolume()
    {
        bgmSlider.value = PlayerPrefs.GetFloat("BGM_Volume");
        sfxSlider.value = PlayerPrefs.GetFloat("SFX_Volume");

        BGMvolumeController();
        SFXvolumeController();

    }

}
