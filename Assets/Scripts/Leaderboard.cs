using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class Leaderboard : MonoBehaviour
{
    List<SavingData> result = new List<SavingData>();
    public GameObject textBundle;
    public TextMeshProUGUI[] ts;
    private int i = 0;
    void Awake()
    {
        List<int> temp = new List<int>();
        //List<int> allScores = new List<int>(FileHandler.ReadFromJSON<int>("scoreboard.json"));
        result = FileHandler.FetchMarks("mdw_privacy.json");
        ts = textBundle.GetComponentsInChildren<TextMeshProUGUI>();
        for (int i = 0; i < result.ToArray().Count(); i++)
        {
            temp.Add(result[i].points);
        }
        temp.Sort();
        temp.Reverse();
        foreach (TextMeshProUGUI child in ts)
        {
            child.text = temp[i].ToString();
            i++;
        }
    }
}
