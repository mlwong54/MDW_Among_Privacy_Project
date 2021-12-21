using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour
{
    private static string[] wordList = {"testing", "hello", "another"};

    public static string returnWord()
    {
        int randomInt = Random.Range(0, wordList.Length);

        return wordList[randomInt];
    }
}
