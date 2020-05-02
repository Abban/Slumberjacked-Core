using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using BBX.Main.Scene;
using BBX.Library.EventManagement;
using BBX.Main.Game;
using BBX.Utility;

namespace Play.Unit.Game
{
    [TestFixture]
    public class SceneControllerTest
    {
        private SceneController _sceneController;
        private GameSettings _gameSettings;
        private StateBroker _stateBroker;
        private GameState _gameState;

        [SetUp]
        public void Setup()
        {
            _gameSettings = Resources.Load<GameSettings>("Settings/Game/GameSettings");
            _stateBroker = Resources.Load<StateBroker>("Settings/Game/GameStateBroker");
            _gameState = Resources.Load<GameState>("Settings/Game/GameState");
            
            _gameState.Initialise(_stateBroker);
            _stateBroker.Initialise();

            _sceneController = new SceneController(
                new SceneTransition(),
                _gameState,
                new EventBus()
            );
        }


        [TearDown]
        public void TearDown()
        {
            SceneManager.UnloadSceneAsync(_gameState.CurrentScene.Value.SceneName);
        }


        [UnityTest]
        public IEnumerator OnLoadScene_LoadsScene()
        {
            var sceneToLoad = _gameSettings.Scenes.MainMenu;
            var loadedScene = string.Empty;

            SceneManager.sceneLoaded += (scene, mode) =>
            {
                loadedScene = scene.name;
            };
            
            yield return _sceneController.LoadScene(sceneToLoad);

            Assert.That(sceneToLoad.SceneName == loadedScene);
        }


        [UnityTest]
        public IEnumerator OnLoadScene_UnloadsPreviousScene()
        {
            var firstSceneToLoad = _gameSettings.Scenes.MainMenu;
            var secondSceneToLoad = _gameSettings.Scenes.Shop;
            var unloadedScene = string.Empty;

            yield return _sceneController.LoadScene(firstSceneToLoad);
            SceneManager.sceneUnloaded += scene => { unloadedScene = scene.name; };
            yield return _sceneController.LoadScene(secondSceneToLoad);

            Assert.That(firstSceneToLoad.SceneName == unloadedScene);
        }

        
        [UnityTest]
        public IEnumerator OnLoadSameScene_DoesNotLoadScene()
        {
            var sceneToLoad = _gameSettings.Scenes.MainMenu;
            var counter = 0;

            yield return _sceneController.LoadScene(sceneToLoad);
            SceneManager.sceneLoaded += (scene, mode) => { counter++; };
            yield return _sceneController.LoadScene(sceneToLoad);

            Assert.That(counter == 0);
        }


        private class EventBus : IEventBus
        {
            public void Subscribe<T>(Action<T> subscriber) where T : IEvent
            {
            }

            public void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
            {
            }

            public void Fire<T>(T payload) where T : IEvent
            {
            }
        }


        private class SceneTransition : ISceneTransition
        {
            public bool IsVisible { get; } = false;

            public IEnumerator Show()
            {
                yield return null;
            }

            public IEnumerator Hide()
            {
                yield return null;
            }
        }
    }
}