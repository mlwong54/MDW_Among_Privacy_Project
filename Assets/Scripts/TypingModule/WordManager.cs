﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordManager : MonoBehaviour
{
    public static WordManager theManager;
    public List<Word> words;
    public WordSpawner wordSpawner;
    private bool hasActiveWord;
    public bool winLose;
    private bool limitUpdate;
    private Word activeWord;
    public int count;
    public bool endGame;

    private void Start()
    {
        limitUpdate = false;
        theManager = this;
        endGame = false;
        winLose = true;
        count = 0;
        StartCoroutine(Spawning());
    }

    IEnumerator Spawning()
    {
        while (count<=10)
        {
            AddWords();
            count++;
            yield return new WaitForSeconds(2.0f);
        }
    }

    void AddWords()
    {
        Word word = new Word(WordGenerator.returnWord(), wordSpawner.SpawnWord());
        words.Add(word);
    }

    public void TypeWord(char letter)
    {
        if(hasActiveWord)
        {
            if(activeWord.GetNextLetter() ==letter)
            {
                activeWord.TypeLetter();
            }
        }
        else
        {
            foreach(Word word in words)
            {
                if(word.GetNextLetter()==letter)
                {
                    activeWord = word;
                    hasActiveWord = true;
                    word.TypeLetter();
                    break;
                }
            }
        }
        if(hasActiveWord && activeWord.WordTyped())
        {
            hasActiveWord = false;
            words.Remove(activeWord);
        }
    }

    public void GameLose()
    {
        words.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {    
            Destroy(enemy);
        }
        UpdateWinScore();
        ReturnToMain();
    }

    public void ReturnToMain()
    {
        LevelLoader.currentLoader.LoadMainModule();
    }

    public void UpdateWinScore()
    {
        if(winLose ==false)
        {
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-100);
        }
        else
        {
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
        }
    }

    private void FixedUpdate()
    {
        if(words.Count==0 && count>10)
        {
            endGame = true;
        }

        if (endGame && limitUpdate ==false)
        {
            GameLose();
            count = 10;
            limitUpdate = true;
        }
    }
}