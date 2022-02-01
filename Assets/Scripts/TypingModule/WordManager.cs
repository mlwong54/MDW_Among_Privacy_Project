using System.Collections;
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
    [SerializeField]
    private GameObject player;
    [SerializeField]
    private GameObject explosionEffect;
    [SerializeField]
    private GameObject winLosePanel;
    [SerializeField]
    private TextMeshProUGUI winLoseText;


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

    public void GameWin()
    {
        words.Clear();
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Instantiate(explosionEffect, enemy.transform.position, Quaternion.identity);
            Destroy(enemy);
        }
        UpdateWinScore();
        Invoke("ReturnToMain", 5.0f);
    }


    public void ReturnToMain()
    {
        LevelLoader.currentLoader.LoadMainModule();
    }

    public void UpdateWinScore()
    {
        winLosePanel.SetActive(true);
        if (winLose ==false)
        {
            winLoseText.text = "YOUR ACCOUNT IS BREACHED AFTER ATTACKED BY PHISHING! YOU LOSE!";
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-1000);
        }
        else
        {
            winLoseText.text = "YOU HAVE SECURED YOUR ACCOUNT FROM PHISHING ATTACK! YOU WIN!";
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+500);
        }
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
    }

    private void FixedUpdate()
    {
        if(words.Count==0 && count>10)
        {
            endGame = true;
        }

        if (endGame && limitUpdate ==false)
        {
                GameWin();
                count = 10;
                limitUpdate = true;
        }
    }
}
