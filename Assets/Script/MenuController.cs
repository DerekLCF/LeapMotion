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
    public Transform DerekSpawnPoint;
    public Transform KennethSpawnPoint;
    public GameObject Derek;
    public GameObject Kenneth;
    public void Start()
    {
        LoadVolume();

    }
    public void Update()
    {

    }
    public void Volume(float vol)
    {
        VolumeText.text = "Volume:" + (vol * 100).ToString("00");
        PlayerPrefs.SetFloat("VolumeValue", vol);
        AudioManager.Instance.SetMusic(vol);
    }

    void LoadVolume() {
        float vol = PlayerPrefs.GetFloat("VolumeValue");
        Debug.Log(vol);
        InteractionSlider.GetComponent<Leap.Unity.Interaction.InteractionSlider>().defaultHorizontalValue = vol;
        VolumeText.text = "Volume:" +(vol *100).ToString("00");
        AudioManager.Instance.SetMusic(vol);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);

    }
    public void Tutorial()
    {

    }
    public void Credit()
    {
        Instantiate(Derek, DerekSpawnPoint.position, DerekSpawnPoint.rotation);
        Instantiate(Kenneth, KennethSpawnPoint.position, KennethSpawnPoint.rotation);
    }
}
