using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeValueChange : MonoBehaviour
{
    [SerializeField] Image soundOnIcon;
    [SerializeField] Image soundOffIcon;

    private AudioSource m_AudioSource;

    // Start is called before the first frame update
    private void Awake()
    {
        m_AudioSource = GetComponent<AudioSource>();
   
        if (!PlayerPrefs.HasKey("MainManagement.muted"))
        {
            PlayerPrefs.SetInt("MainManagement.muted", 0);
            Load();
        }
        else
        {
            Load();
        }

        UpdateButtonIcon();
        AudioListener.pause = MainManagement.muted;
    }

    // Update is called once per frame
    void Update()
    {
        m_AudioSource.volume = MainManagement.volumeSound;
    }

    public void SetVolume(float vol)
    {
        MainManagement.volumeSound = vol;

        if (vol <= -1)
        {
            MainManagement.muted = false;
            OnButtonPress();
            UpdateButtonIcon();
        } else
        {
            MainManagement.muted = true;
            OnButtonPress();
            UpdateButtonIcon();
        }
    }

    public void OnButtonPress()
    {
        if (MainManagement.muted == false)
        {
            MainManagement.muted = true;
            AudioListener.pause = true;
            UpdateButtonIcon();
        }
        else
        {
            MainManagement.muted = false;
            AudioListener.pause = false;
            UpdateButtonIcon();
        }

        Save();
    }

    private void UpdateButtonIcon()
    {
        if (MainManagement.muted == false)
        {
            soundOffIcon.enabled = false;
            soundOnIcon.enabled = true;
        }
        else
        {
            soundOffIcon.enabled = true;
            soundOnIcon.enabled = false;
        }
    }

    private void Load()
    {
        MainManagement.muted = PlayerPrefs.GetInt("MainManagement.muted") == 1;
    }

    private void Save()
    {
        PlayerPrefs.SetInt("MainManagement.muted", MainManagement.muted ? 1 : 0);
    }
}
