using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch : MonoBehaviour
{
    [SerializeField]
    private GameObject explosionEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.gameObject.SetActive(false);
            Instantiate(explosionEffect, collision.gameObject.transform.position, Quaternion.identity);
            WordManager.theManager.winLose = false;
            WordManager.theManager.endGame = true;
        }
    }

}
