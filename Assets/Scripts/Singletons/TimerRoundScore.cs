using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerRoundScore : MonoBehaviour
{
    public static TimerRoundScore CurrentScoreHandler;
    public float timerValue = 100f;
    public TextMeshProUGUI timerUI;
    public TextMeshProUGUI roundText;
    public TextMeshProUGUI winText;

    private int RoundCount;
    private int WinCount;

    private void Awake()
    {
        CurrentScoreHandler = this;
    }
    private void Start()
    {
        RoundCount = 0;
        WinCount = 0;
    }

    private void Update()
    {
        timerValue -= Time.deltaTime;

        float minutes = Mathf.FloorToInt(timerValue / 60);
        float seconds = Mathf.FloorToInt(timerValue % 60);

        timerUI.text = string.Format("{0:00}:{1:00}", minutes, seconds);

        if(timerValue <=0)
        {
            EndLoseGameCondition();
        }
    }

    public void RoundTextUpdate()
    {
        RoundCount++;
        roundText.text = RoundCount.ToString();

        if(RoundCount >=4)
        {
            Debug.Log(WinCount);
            if (WinCount>=0)
            {
                Debug.Log("your wincount trigger");
                EndWinGameCondition();
            }
            else
            {
                Debug.Log("your wincount trigger not here");
                EndLoseGameCondition();
            }
        }
    }


    public void WinTextUpdate(int value)
    {
        WinCount+= value;
        winText.text = WinCount.ToString();
    }

    void EndWinGameCondition()
    {
        //Debug.Log("End game condition reached!");
        PlayerPrefs.SetInt("RoundScores", WinCount);
        Invoke("GameOverWin", 3.0f);
        
    }

    void EndLoseGameCondition()
    {
        PlayerPrefs.SetInt("RoundScores", WinCount);
        Invoke("GameOverLose", 3.0f);
    }

    void GameOverWin()
    {
        LevelLoader.currentLoader.LoadGameOverWin();
    }

    void GameOverLose()
    {
        LevelLoader.currentLoader.LoadGameOverLose();
    }
}
