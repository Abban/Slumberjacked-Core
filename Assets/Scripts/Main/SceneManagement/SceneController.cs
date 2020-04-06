using System.Collections;
using UniRx;
using BBX.Library.EventManagement;
using UnityEngine.SceneManagement;

namespace BBX.Main.SceneManagement
{
    public class SceneController
    {
        private GameSettings.ScenesReferences _scenes;
        private ISceneTransition _transition;
        private IEventBus _gameEventBus;

        public SceneReference CurrentScene { get; private set; }

        public SceneController(
            GameSettings.ScenesReferences scenes,
            ISceneTransition transition,
            IEventBus gameEventBus)
        {
            _scenes = scenes;
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