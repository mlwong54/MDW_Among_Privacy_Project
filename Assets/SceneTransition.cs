using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public void Transition(int num)
    {
        SceneManager.LoadScene(num);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
