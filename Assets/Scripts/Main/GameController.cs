using UnityEngine;
using BBX.Library.EventManagement;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    public class GameController
    {
        private SceneController _sceneController;
        private GameSettings _settings;
        private IEventBus _gameEventBus;

        public GameController(
            SceneController sceneController,
            GameSettings settings,
            IEventBus gameEventBus)
        {
            _sceneController = sceneController;
            _settings = settings;
            _gameEventBus = gameEventBus;
        }


        public void OnEnable()
        {
            _gameEventBus.Subscribe(GameEvents.OnGameLoaded, OnSceneLoaded);
        }


        public void OnDisable()
        {
            _gameEventBus.Unsubscribe(GameEvents.OnGameLoaded, OnSceneLoaded);
        }

        public void Start()
        {
            if (_sceneController.CurrentScene == null)
            {
                _sceneController.LoadScene(_settings.Scenes.DefaultScene);
            }
        }

        public void OnSceneLoaded()
        {
            Debug.Log("Scene Loaded");
        }
    }
}