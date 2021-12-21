using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModuleTrigger : MonoBehaviour
{
    public int id;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameEvent.current.boolsCheck[id-1] == true)
        {
            GameEvent.current.MinigameTrigger(id);
        }
    }

}
