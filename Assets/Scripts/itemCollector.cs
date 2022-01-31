using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class itemCollector : MonoBehaviour
{
    private int itemCollected = 0;
    [SerializeField] private Text itemText;
    [SerializeField] private AudioSource collectSoundEffect;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Item"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            itemCollected++;
            itemText.text = "Item Collected: " + itemCollected;
        }
    }
    
}
