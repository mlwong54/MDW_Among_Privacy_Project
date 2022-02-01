using UnityEngine;

public class PlatformerQuizBank : MonoBehaviour
{
    public itemCollector thisItem;
    public int initial = 0;
    public int tempIndex;
    public string[] questions;
    public bool[] answers;

    public void CheckAnswer(bool boolNum)
    {
        if(boolNum == answers[tempIndex])
        {
            Debug.Log("correct answer!");
            thisItem.CorrectQuiz();
        }
        else
        {
            Debug.Log("wrong answer!");
            thisItem.WrongQuiz();
        }
    }

}
