using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string name)
    {
        if (!string.IsNullOrEmpty(name))
        {
            SceneManager.LoadScene(name);
        }
    }

    public void RestartCurrentScene()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
