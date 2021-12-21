using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEvent : MonoBehaviour
{
    public static GameEvent current;
    public bool[] boolsCheck;
    public bool AddEventOnce;

     private void Awake()
    {
        current = this;
        AddEventOnce = false;
        for(int i =0; i < boolsCheck.Length;i++)
        {
            boolsCheck[i] = true;
        }
    }

    public event Action<int> onFinishMinigame;
    public void MinigameTrigger(int id)
    {
        if(onFinishMinigame != null)
        {
            onFinishMinigame(id);
        }
    }
}
