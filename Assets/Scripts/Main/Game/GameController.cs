using BBX.Main.Scene;
using BBX.Utility;
using UnityEngine;
using EventBus = BBX.Utility.EventBus;

namespace BBX.Main.Game
{
    /// <summary>
    /// TODO: Make sure only business logic ends up in here
    /// </summary>
    public class GameController
    {
        private StateBroker _stateBroker;
        private EventBus _gameEventBus;
        private SceneController _sceneController;
        private GameSettings _settings;
        private GameState _state;
        private MonoBehaviour _coroutineRunner;

        public GameController(
            StateBroker stateBroker,
            EventBus gameEventBus,
            SceneController sceneController,
            GameSettings settings,
            GameState state,
            MonoBehaviour coroutineRunner)
        {
            _stateBroker = stateBroker;
            _gameEventBus = gameEventBus;
            _sceneController = sceneController;
            _settings = settings;
            _state = state;
            _coroutineRunner = coroutineRunner;
        }


        public void OnEnable()
        {
            _gameEventBus.Subscribe<ChangeSceneEvent>(OnChangeScene);
            _gameEventBus.Subscribe<SceneChangedEvent>(OnSceneLoaded);
        }


        public void OnDisable()
        {
            _gameEventBus.Unsubscribe<ChangeSceneEvent>(OnChangeScene);
            _gameEventBus.Unsubscribe<SceneChangedEvent>(OnSceneLoaded);
        }

        
        public void Start()
        {
            LoadScene(_settings.Scenes.DefaultScene);
        }


        public void Update()
        {
            
        }

        
        private void OnChangeScene(ChangeSceneEvent sceneEvent)
        {
            if (_state.LoadingState.Value == GameState.LoadingStates.Idle)
            {
                LoadScene(sceneEvent.Scene);
            }
        }


        private void OnSceneLoaded(SceneChangedEvent sceneEvent)
        {
            _state.LoadingState.Value = GameState.LoadingStates.Idle;
            _state.CurrentScene.Value = sceneEvent.Scene;
            _stateBroker.NotifyObservers();
        }


        private void LoadScene(SceneReference scene)
        {
            _state.LoadingState.Value = GameState.LoadingStates.Loading;
            _coroutineRunner.StartCoroutine(_sceneController.LoadScene(scene));
            _stateBroker.NotifyObservers();
        }
    }
}