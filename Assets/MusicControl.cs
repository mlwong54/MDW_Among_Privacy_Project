using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class MusicControl : MonoBehaviour
{
    [SerializeField]
    private AudioMixer myAudioMixer;
    // Start is called before the first frame update
    void Start()
    {
        float currentVolume =PlayerPrefs.GetFloat("mixerVolume");
        myAudioMixer.SetFloat("MasterVolume", Mathf.Log10(currentVolume) * 20);
    }

}
