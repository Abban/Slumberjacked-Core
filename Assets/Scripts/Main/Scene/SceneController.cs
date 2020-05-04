using System.Collections;
using UnityEngine.SceneManagement;
using BBX.Main.Game;
using BBX.Library.EventManagement;
using BBX.Main.Scene.Interfaces;

namespace BBX.Main.Scene
{
    public class SceneController
    {
        private ISceneTransition _transition;
        private GameState _gameState;
        private IEventBus _gameEventBus;
        
        
        public SceneController(
            ISceneTransition transition,
            GameState gameState,
            IEventBus gameEventBus)
        {
            _transition = transition;
            _gameState = gameState;
            _gameEventBus = gameEventBus;
        }
        

        public IEnumerator LoadScene(ISceneReference scene)
        {
            _gameState.LoadingState.Value = GameState.LoadingStates.Loading;

            yield return _transition.Show();
            
            if (scene != _gameState.CurrentScene.Value)
            {
                yield return UnLoadScene();
                yield return LoadScene(scene.SceneName);
                _gameState.CurrentScene.Value = scene;
            }
            
            yield return _transition.Hide();
            
            _gameState.LoadingState.Value = GameState.LoadingStates.Idle;
            _gameEventBus.Fire(new SceneChangedEvent(scene));
        }

        
        /// <summary>
        /// Fire unload scene async and wait
        /// </summary>
        /// <returns></returns>
        private IEnumerator UnLoadScene()
        {
            if (_gameState.CurrentScene.Value != null)
            {
                yield return SceneManager.UnloadSceneAsync(_gameState.CurrentScene.Value.SceneName);
            }
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