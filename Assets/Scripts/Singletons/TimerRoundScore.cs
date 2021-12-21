using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
            EndGameCondition();
        }
    }

    public void RoundTextUpdate()
    {
        RoundCount++;
        roundText.text = RoundCount.ToString();

        if(RoundCount >=4)
        {
            EndGameCondition();
        }
    }

    public void WinTextUpdate(int value)
    {
        WinCount+= value;
        winText.text = WinCount.ToString();
    }

    void EndGameCondition()
    {
        Debug.Log("End game condition reached!");
    }
}
