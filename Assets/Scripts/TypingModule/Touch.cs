using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            Debug.Log("GAME OVER");
            WordManager.theManager.winLose = false;
            WordManager.theManager.endGame = true;
        }
    }

}
