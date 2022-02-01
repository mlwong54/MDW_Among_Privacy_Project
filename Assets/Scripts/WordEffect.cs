using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WordEffect : MonoBehaviour
{
    public float delay = 0.1f;
    public int arraySize;
    public string[] fullText;
    private string currentText = "";
    public GameObject nextButton;
    public GameObject startButton;
    //public AudioClip clip;
    public AudioSource sourceClip;
    private int count;

    private void Start()
    {
        count = 0;
        StartCoroutine(ShowText(count));
    }

    IEnumerator ShowText(int num)
    {
        sourceClip.Play();
        for(int i =0; i<= fullText[num].Length; i++)
        {
            currentText = fullText[num].Substring(0, i);
            this.GetComponent<TextMeshProUGUI>().text = currentText;
            if(i==fullText[num].Length)
            {
                if (num < arraySize)
                {
                    sourceClip.Stop();
                    nextButton.SetActive(true); 
                }
                else
                {
                    sourceClip.Stop();
                    startButton.SetActive(true);
                } 
            }
            yield return new WaitForSeconds(delay);
        }
    }

    public void ContinueNextDialogue()
    {
        if (count<arraySize)
        {   count++;
            StartCoroutine(ShowText(count));
            nextButton.SetActive(false);
        }
        
    }
}
