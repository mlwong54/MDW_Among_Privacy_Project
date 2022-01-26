using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerAnimation : MonoBehaviour
{
    [SerializeField]
    private Text TextEffect;
    private float currentNum;
    private float Rate = 10.0f;

    private void Start()
    {
        currentNum = 0f;
    }
    public void UpdateTextEffect()
    {
        var tempColor = TextEffect.color;
        tempColor.a = currentNum;
        TextEffect.color = tempColor;
    }

    public void SetTextEffect(string currentText)
    {
        TextEffect.text = currentText;
        currentNum = 255.0f;
    }

    void Update()
    {
        if (TextEffect.color.a <= 0 && currentNum==0f)
        {
            return;
        }
        else
        {
            currentNum -= Rate;
            UpdateTextEffect();
        }
    }
}
