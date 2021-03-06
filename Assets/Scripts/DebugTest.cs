using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugTest : MonoBehaviour
{
    private bool endGame;
    private bool winLose;
    private bool checkOnce; //used for make sure Score only update once in the Singleton

    private void Start()
    {
        endGame = false;
        winLose = false;
        checkOnce = false;
    }


    // Update is called once per frame
    void Update()
    {
        if (endGame == false)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                endGame = true;
            }
        }

        if (endGame == true && checkOnce == false)
        {
            AddEndScore();
            checkOnce = true;
        }
    }

    void AddEndScore()
    {
        winLose = true;
        UpdateWinScore();
        ReturnToMain();
    }

    public void ReturnToMain()
    {
        LevelLoader.currentLoader.LoadMainModule();
    }

    public void UpdateWinScore()
    {
        if (winLose == false)
        {
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-100);
        }
        else
        {
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
        }
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
    }
}
