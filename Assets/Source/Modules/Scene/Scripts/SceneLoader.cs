using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Source.Modules.Scene.Scripts
{
    public class SceneLoader : MonoBehaviour
    {
        public void Load(string nameScene, Action onLoaded = null)
        {
            StartCoroutine(Loading(nameScene, onLoaded));
        }

        private IEnumerator Loading(string nameScene, Action onLoaded)
        {
            var asyncScene = SceneManager.LoadSceneAsync(nameScene);

            while (asyncScene.isDone == false)
                yield return null;

            onLoaded?.Invoke();
        }
    }
}