using BBX.Library.EventManagement;
using BBX.Main.SceneManagement;
using BBX.Utility;

namespace BBX.Main
{
    public class GameController
    {
        private SceneController _sceneController;
        private GameSettings _settings;
        private StateBroker _stateBroker;
        private GameState _state;
        private IEventBus _gameEventBus;

        public GameController(
            SceneController sceneController,
            GameSettings settings,
            StateBroker stateBroker,
            GameState state,
            IEventBus gameEventBus)
        {
            _sceneController = sceneController;
            _settings = settings;
            _stateBroker = stateBroker;
            _state = state;
            _gameEventBus = gameEventBus;
        }


        public void OnEnable()
        {
            _gameEventBus.Subscribe<SceneChangedEvent>(OnSceneLoaded);
            _gameEventBus.Subscribe<ChangeSceneEvent>(OnChangeScene);
        }


        public void OnDisable()
        {
            _gameEventBus.Unsubscribe<SceneChangedEvent>(OnSceneLoaded);
            _gameEventBus.Unsubscribe<ChangeSceneEvent>(OnChangeScene);
        }

        
        public void Start()
        {
            _state.Initialise(_stateBroker, null);

            if (_sceneController.CurrentScene == null)
            {
                _sceneController.LoadScene(_settings.Scenes.DefaultScene);
            }
        }

        
        private void OnChangeScene(ChangeSceneEvent sceneEvent)
        {
            _sceneController.LoadScene(sceneEvent.Scene);
        }

        
        private void OnSceneLoaded(SceneChangedEvent sceneEvent)
        {
            _state.CurrentScene.Value = sceneEvent.Scene;
            _stateBroker.NotifyObservers();
        }
    }
}