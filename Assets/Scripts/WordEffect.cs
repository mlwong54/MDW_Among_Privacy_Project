using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public string[] fullText;
    private string currentText = "";
    public GameObject nextButton;
    public GameObject startButton;
    private int count;

    private void Start()
    {
        count = 0;
        StartCoroutine(ShowText(count));
    }

    IEnumerator ShowText(int num)
    {
        for(int i =0; i<= fullText[num].Length; i++)
        {
            currentText = fullText[num].Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            if(i==fullText.Length)
            { nextButton.SetActive(true); }
            yield return new WaitForSeconds(delay);
        }
    }

    public void ContinueNextDialogue()
    {
        if (count<1)
        {   count++;
            StartCoroutine(ShowText(count));
            nextButton.SetActive(false);
        }
        else
        {
            nextButton.SetActive(false);
            startButton.SetActive(true);
        }
    }
}
