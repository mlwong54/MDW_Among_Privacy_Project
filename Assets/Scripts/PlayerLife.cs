using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerLife : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rg;
    [SerializeField] private AudioSource DeathSoundEffect;
    [SerializeField] private TextMeshProUGUI uiText;
    [SerializeField] private GameObject uiMenu;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rg = GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }

    private void Die()
    {
        uiText.text = "you lose";
        uiMenu.SetActive(true);
        DeathSoundEffect.Play();
        anim.SetTrigger("dead");
        rg.bodyType = RigidbodyType2D.Static;
    }

    private void RestartLvl()
    {
        TimerRoundScore.CurrentScoreHandler.WinTextUpdate(-1000);
        TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
        LevelLoader.currentLoader.LoadMainModule();
    }


}
