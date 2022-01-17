using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    [SerializeField] string filename;

    List<SavingData> entries = new List<SavingData>();
    public TextMeshProUGUI scoreDisplay;


    // Start is called before the first frame update
    void Awake()
    {
        entries = FileHandler.ReadFromJSON<SavingData>(filename);
        ManageListScore();
        DisplayScore();
    }

    void DisplayScore()
    {
        scoreDisplay.text = PlayerPrefs.GetInt("RoundScores").ToString();
    }

    public void ManageListScore()
    {
        int newscore = PlayerPrefs.GetInt("RoundScores");
        entries.Add(new SavingData(newscore));
        FileHandler.SaveToJSON<SavingData>(entries, filename);
    }
}
