using System.Collections;
using UniRx;
using BBX.Library.EventManagement;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BBX.Main.SceneManagement
{
    public class SceneController
    {
        private ISceneTransition _transition;
        private IEventBus _gameEventBus;

        public SceneReference CurrentScene { get; private set; }

        public SceneController(
            ISceneTransition transition,
            IEventBus gameEventBus)
        {
            _transition = transition;
            _gameEventBus = gameEventBus;
        }

        
        public void LoadScene(SceneReference scene)
        {
            Observable.FromCoroutine(_transition.Show)
                .SelectMany(UnLoadScene)
                .SelectMany(LoadScene(scene.SceneName))
                .SelectMany(_transition.Hide)
                .Subscribe(x =>
                {
                    CurrentScene = scene;
                    _gameEventBus.Fire(new SceneChangedEvent(scene));
                });
        }
        
        
        /// <summary>
        /// Fire unload scene async and wait
        /// </summary>
        /// <returns></returns>
        private IEnumerator UnLoadScene()
        {
            if (CurrentScene == null) yield break;

            yield return SceneManager.UnloadSceneAsync(CurrentScene.SceneName);
        }

        
        /// <summary>
        /// Fire load scene async and wait
        /// </summary>
        /// <returns></returns>
        private static IEnumerator LoadScene(string scene)
        {
            yield return SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        }
    }
}