using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextLevel()
    {
        if (SceneManager.sceneCountInBuildSettings <= 1)
        {
            Debug.LogError("Scenes are not added to the Build Settings. Go to file > Build settings and add all the scenes.");
            return;
        }

        int current = SceneManager.GetActiveScene().buildIndex;
        int next = (current + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(next);
    }

}
