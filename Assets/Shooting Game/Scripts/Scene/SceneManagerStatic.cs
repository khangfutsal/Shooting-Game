using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneManagerStatic
{
    public static void SceneLoad(string name)
    {
        SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
    }

    public static void SceneUnload(string name)
    {
        SceneManager.UnloadSceneAsync(name);
    }

    public static void SceneLoadAgain(string name)
    {
        Scene currentScene = SceneManager.GetSceneByName(name);

        if (currentScene.isLoaded)
        {
            SceneManager.UnloadSceneAsync(currentScene).completed += (AsyncOperation op) =>
            {
                SceneManager.LoadSceneAsync(name, LoadSceneMode.Additive);
            };
        }
    }
}
