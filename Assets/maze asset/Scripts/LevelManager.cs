﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelManager : MonoBehaviour
{
    bool gameHasEnded = false;
    public GameObject menu;
    public TextMeshProUGUI UItext;

    void Start()
    {
        FindObjectOfType<ThemeMusic>().Play();
    }

    public void EndGame()
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<LooseMusic>().Play();
            menu.SetActive(true);
            UItext.text = "you lose";
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-500);
            Invoke("ReturnToMain", 3.0f);
        }

    }

    public void FinishGame()
    {

        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            FindObjectOfType<VictoryMusic>().Play();
            menu.SetActive(true);
            UItext.text = "you win";
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+1000);
            Invoke("ReturnToMain", 5.0f);
        }
    }

    public void ReturnToMain()
    {
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }

   
    public bool IsGameOver()
    {
        return gameHasEnded;
    }
}
