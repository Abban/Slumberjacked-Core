using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using BBX.Main.Scene;
using BBX.Library.EventManagement;
using BBX.Main.Game;

namespace Play.Unit.Game
{
    [TestFixture]
    public class SceneControllerTest
    {
        private SceneController _sceneController;
        private GameSettings _gameSettings;
        private GameState _gameState;

        [SetUp]
        public void Setup()
        {
            _gameSettings = Resources.Load<GameSettings>("Settings/Game/GameSettings");
            _gameState = Resources.Load<GameState>("Settings/Game/GameState");

            _sceneController = new SceneController(
                new SceneTransition(),
                _gameState,
                new EventBus()
            );
        }


        [UnityTest]
        public IEnumerator OnLoadScene_LoadsScene()
        {
            var sceneToLoad = _gameSettings.Scenes.MainMenu;
            var loaded = false;
            var loadedScene = string.Empty;
            var counter = 0;

            SceneManager.sceneLoaded += (scene, mode) =>
            {
                loaded = true;
                loadedScene = scene.name;
            };
            _sceneController.LoadScene(sceneToLoad);

            while (!loaded && counter < 10)
            {
                counter++;
                yield return new WaitForSeconds(1);
            }

            Assert.That(sceneToLoad.SceneName == loadedScene);
        }


        [UnityTest]
        public IEnumerator OnLoadScene_UnloadsPreviousScene()
        {
            var firstSceneToLoad = _gameSettings.Scenes.MainMenu;
            var secondSceneToLoad = _gameSettings.Scenes.Shop;
            var loaded = false;
            var unloaded = false;
            var unloadedScene = string.Empty;
            var counter = 0;

            SceneManager.sceneLoaded += (scene, mode) => { loaded = true; };
            _sceneController.LoadScene(firstSceneToLoad);
            while (!loaded && counter < 10)
            {
                counter++;
                yield return new WaitForSeconds(1);
            }

            SceneManager.sceneUnloaded += scene =>
            {
                unloaded = true;
                unloadedScene = scene.name;
            };
            _sceneController.LoadScene(secondSceneToLoad);

            counter = 0;
            while (!unloaded && counter < 10)
            {
                counter++;
                yield return new WaitForSeconds(1);
            }

            Assert.That(firstSceneToLoad.SceneName == unloadedScene);
        }

        
        [UnityTest]
        public IEnumerator OnLoadSameScene_DoesNotLoadScene()
        {
            throw new NotImplementedException();
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
            public bool IsVisible { get; }

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