using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;
using Leap.Unity.Attributes;

public class MenuController : MonoBehaviour
{

    public TMP_Text VolumeText;
    public GameObject InteractionSlider;
    public void Start()
    {
        LoadVolume();

    }
    public void Update()
    {
    }
    public void Volume(float vol)
    {
        VolumeText.text = vol.ToString();
        PlayerPrefs.SetFloat("VolumeValue", vol);
    }

    void LoadVolume() {
        float vol = PlayerPrefs.GetFloat("VolumeValue");
       // InteractionSlider.GetComponent<InteractionSlider>()
    }
    public void StartGame()
    {
        SceneManager.LoadScene("Game");

    }
    public void Tutorial()
    {

    }
    public void Credit()
    {

    }
}
