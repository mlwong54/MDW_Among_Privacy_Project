using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeForfeitGame : MonoBehaviour
{
    public void ForfeitGame()
    {
        Time.timeScale = 1;
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-500);
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }
}
