using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextDisplay : MonoBehaviour
{
    public TextMeshPro Text;
    public GameObject explosionEffect;
    public void SetWord(string word)
    {
        Text.text = word;
    }

    public void RemoveLetter()
    {
        Text.text = Text.text.Remove(0, 1);
        Text.color = Color.red;
    }

    public void RemoveWord()
    {
        Destroy(transform.parent.gameObject);
        Instantiate(explosionEffect, transform.position, Quaternion.identity);
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
        //TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
    }

}
