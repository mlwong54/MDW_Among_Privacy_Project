using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public static LevelLoader currentLoader;

    private void Awake()
    {
        currentLoader = this;   
    }

    private enum _levelChunk
    {
        MainLevel =3,
        TypingModule =4,
        Module2 =5,
        Module3 =6,
        Module4 =7
    }

    List<AsyncOperation> scenesToLoad = new List<AsyncOperation>();

    private void Start()
    {
        if (!isSceneLoaded(_levelChunk.MainLevel))
        {
            scenesToLoad.Add(SceneManager.LoadSceneAsync((int)_levelChunk.MainLevel, LoadSceneMode.Additive));
        }
    }
    private bool isSceneLoaded(_levelChunk targetSceneIndex)
    {
        int numSceneLoaded = SceneManager.sceneCount;
        Scene targetScene = SceneManager.GetSceneByBuildIndex((int)targetSceneIndex);
        for (int i = 0; i < numSceneLoaded; i++)
        {
            Scene scene = SceneManager.GetSceneAt(i);
            if (!(scene.name == targetScene.name) && targetScene.isLoaded)
            {
                return true;
            }
        }
        return false;
    }

    private void LoadLevelChunk(_levelChunk targetSceneIndex)
    {
        if (!isSceneLoaded(targetSceneIndex))
        {
            SceneManager.LoadSceneAsync((int)targetSceneIndex, LoadSceneMode.Additive);
        }
    }

    private void UnloadLevelChunk(_levelChunk targetSceneIndex)
    {
        if (isSceneLoaded(targetSceneIndex))
        {
            SceneManager.UnloadSceneAsync((int)targetSceneIndex);
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    public void LoadMainModule()
    {
        GameEvent.current.AddEventOnce = true;
        UnloadLevelChunk(_levelChunk.TypingModule);
        UnloadLevelChunk(_levelChunk.Module2);
        UnloadLevelChunk(_levelChunk.Module3);
        UnloadLevelChunk(_levelChunk.Module4);
        LoadLevelChunk(_levelChunk.MainLevel);
    }

    public void LoadGameOverWin()
    {
        UnloadLevelChunk(_levelChunk.MainLevel);
        UnloadLevelChunk(_levelChunk.TypingModule);
        UnloadLevelChunk(_levelChunk.Module2);
        UnloadLevelChunk(_levelChunk.Module3);
        UnloadLevelChunk(_levelChunk.Module4);
        SceneManager.LoadScene(8);
    }

    public void LoadGameOverLose()
    {
        UnloadLevelChunk(_levelChunk.MainLevel);
        UnloadLevelChunk(_levelChunk.TypingModule);
        UnloadLevelChunk(_levelChunk.Module2);
        UnloadLevelChunk(_levelChunk.Module3);
        UnloadLevelChunk(_levelChunk.Module4);
        SceneManager.LoadScene(9);
    }

    public void LoadModule(int id)
    {
        id = id + 3;
        if(id == (int)_levelChunk.TypingModule)
        {
            UnloadLevelChunk(_levelChunk.MainLevel);
            LoadLevelChunk(_levelChunk.TypingModule);
        }
        else if (id == (int)_levelChunk.Module2)
        {
            UnloadLevelChunk(_levelChunk.MainLevel);
            LoadLevelChunk(_levelChunk.Module2);
        }
        else if (id == (int)_levelChunk.Module3)
        {
            UnloadLevelChunk(_levelChunk.MainLevel);
            LoadLevelChunk(_levelChunk.Module3);
        }
        else if (id == (int)_levelChunk.Module4)
        {
            UnloadLevelChunk(_levelChunk.MainLevel);
            LoadLevelChunk(_levelChunk.Module4);
        }

    }
}
