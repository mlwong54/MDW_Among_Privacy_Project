using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MinigameController : MonoBehaviour
{
    public int id;
    // Start is called before the first frame update
    void Start()
    {
        if(GameEvent.current.AddEventOnce == false)
        {
            GameEvent.current.onFinishMinigame += StartMinigame;
        }
    }

    void StartMinigame(int id)
    {
        if (id == this.id)
        {
            Debug.Log("start minigame ID: " + id);
            LevelLoader.currentLoader.LoadModule(id);
            TimerRoundScore.CurrentScoreHandler.RoundTextUpdate();
            GameEvent.current.boolsCheck[id - 1] = false;
        }
    }

}
