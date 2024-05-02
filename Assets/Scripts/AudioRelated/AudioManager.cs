using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    public Sound[] bgm, sfx;

    public AudioSource bgmSrc, sfxSrc;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        BGMplay("Theme_1");
    }

    public void BGMplay(string name)
    {
        Sound bgmSound = Array.Find(bgm, x => x.audioName == name);

        if (bgmSound == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            bgmSrc.clip = bgmSound.clip;
            bgmSrc.Play();
        }

    }

    public void SFXplay(string name)
    {
        Sound sfxSound = Array.Find(sfx, x => x.audioName == name);

        if (sfxSound == null)
        {
            Debug.Log("Sound not found!");
        }
        else
        {
            sfxSrc.clip = sfxSound.clip;
            sfxSrc.Play();
        }
    }

    public void BGMVolume(float volume)
    {
        bgmSrc.volume = volume;
    }

    public void SFXVolume(float volume)
    {
        sfxSrc.volume = volume;
    }

}
