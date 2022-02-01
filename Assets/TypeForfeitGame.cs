using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypeForfeitGame : MonoBehaviour
{
    public void ForfeitGame()
    {
        Time.timeScale = 1;
        WordManager.theManager.winLose = false;
        WordManager.theManager.endGame = true;
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-1000);
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }
}
