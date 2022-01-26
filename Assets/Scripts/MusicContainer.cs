﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicContainer : MonoBehaviour
{
    public AudioClip otherClip;
    // Start is called before the first frame update
    void Start()
    {
        AudioSource audio = GetComponent<AudioSource>();
        audio.PlayOneShot(otherClip);
    }

}
