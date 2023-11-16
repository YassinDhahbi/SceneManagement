using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace YassinUtils.SceneManager
{
    public class SceneManagerSingelton : MonoBehaviour
    {
        public static SceneManagerSingelton Instance;

        // Loading and Unloading can be done in two ways:
        // =====> First way
        public void LoadSceneAdditively(string sceneName, bool isLoaded)
        {
            if (isLoaded)
            {
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        // =====> Second way
        public void LoadSceneAdditively(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        }

        public void UnloadLoadSceneAdditively(string sceneName)
        {
            UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
        }
    }

    [Serializable]
    public class SceneAssetLoader
    {
        [SerializeField]
        private string sceneName;

        public void LoadSceneAddtitively(bool isLoaded)
        {
            if (isLoaded)
            {
                UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.UnloadSceneAsync(sceneName);
            }
        }

        public string GetSceneName()
        {
            return sceneName;
        }

        public void SetSceneName(string targetSceneName)
        {
            sceneName = targetSceneName;
        }
    }
}