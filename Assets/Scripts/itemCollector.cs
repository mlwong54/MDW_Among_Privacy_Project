using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class itemCollector : MonoBehaviour
{
    private int itemCollected = 0;
    private int quizAnswered = 0;
    [SerializeField] private Text itemText;
    [SerializeField] private Text quizText;
    [SerializeField] private TextMeshProUGUI quizQues;
    [SerializeField] private GameObject quizPanel;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            itemCollected++;
            itemText.text = "Item Collected: " + itemCollected;
            TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
        }
        else if(collision.gameObject.CompareTag("CoinQuiz"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            //quizAnswered++;
            //quizText.text = "Quiz Answered: " + quizAnswered;
            PlatformerQuizBank quizzes = quizQues.GetComponent<PlatformerQuizBank>();
            quizzes.tempIndex = quizAnswered;
            quizQues.text = quizzes.questions[quizAnswered];
            Time.timeScale = 0;
            quizPanel.SetActive(true);
            //TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
        }
    }

    public void CorrectQuiz()
    {
        Time.timeScale = 1;
        quizPanel.SetActive(false);
        quizAnswered++;
        quizText.text = "Quiz Answered: " + quizAnswered;
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+100);
    }
    public void WrongQuiz()
    {
        Time.timeScale = 1;
        quizPanel.SetActive(false);
        quizAnswered++;
        quizText.text = "Quiz Answered: " + quizAnswered;
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-300);
    }

}
