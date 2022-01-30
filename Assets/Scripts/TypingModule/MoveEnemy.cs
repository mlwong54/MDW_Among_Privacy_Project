using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    private float moveSpeed = 2f;
    private void Update()
    {
        transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
    }
}
