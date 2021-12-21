using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordSpawner : MonoBehaviour
{
    public GameObject wordPrefab;
    public GameObject allTexts;

    public TextDisplay SpawnWord()
    {
        Vector3 randomPosition = new Vector3(Random.Range(10f, 20f), Random.Range(-4f, 4f));

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity, allTexts.transform);
        TextDisplay wordDisplay = wordObj.GetComponentInChildren<TextDisplay>();

        return wordDisplay;
    }
}
