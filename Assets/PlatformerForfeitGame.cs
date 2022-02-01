using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformerForfeitGame : MonoBehaviour
{
    public void ForfeitGame()
    {
        Time.timeScale = 1;
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-1000);
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }
}
