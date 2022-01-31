using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MainMenuPanels : MonoBehaviour
{
    [SerializeField]
    private GameObject[] panels;
    [SerializeField] 
    private AudioMixer myAudioMixer;

    public void EnablePanel(int num)
    {
        panels[num].SetActive(true);
    }

    public void DisablePanel(int num)
    {
        panels[num].SetActive(false);
    }
    public void SetVolume(float sliderValue)
    {
        myAudioMixer.SetFloat("MasterVolume", Mathf.Log10(sliderValue) * 20);
    }
}
 