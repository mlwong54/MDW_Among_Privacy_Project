using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Finish : MonoBehaviour
{
    private AudioSource finishSound;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject uiMenu;
    private bool LevelCompleted = false;
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.name == "Player" && !LevelCompleted)
        {
            uiText.text = "you win";
            uiMenu.SetActive(true);
            finishSound.Play();
            LevelCompleted = true;
            Invoke("CompleteLevel", 2f);
        }

    }

    private void CompleteLevel()
    {
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(+1000);
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }

}
