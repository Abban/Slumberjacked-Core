using BBX.Main.LevelSelectManagement;
using BBX.Main.SaveManagement;
using BBX.Main.SceneManagement;
using BBX.Utility;
using EventBus = BBX.Utility.EventBus;

namespace BBX.Main.GameManagement
{
    /// <summary>
    /// TODO: Make sure only business logic ends up in here
    /// </summary>
    public class GameController
    {
        private SceneController _sceneController;
        private SaveController _saveController;
        private GameSettings _settings;
        private StateBroker _stateBroker;
        private GameState _state;
        private EventBus _gameEventBus;
        private LevelRegistry _levelRegistry;

        public GameController(
            SceneController sceneController,
            SaveController saveController,
            GameSettings settings,
            StateBroker stateBroker,
            GameState state,
            EventBus gameEventBus,
            LevelRegistry levelRegistry)
        {
            _sceneController = sceneController;
            _saveController = saveController;
            _settings = settings;
            _stateBroker = stateBroker;
            _state = state;
            _gameEventBus = gameEventBus;
            _levelRegistry = levelRegistry;
        }

        
        public void Initialise()
        {
            _state.Initialise(_stateBroker, null);
            _gameEventBus.Initialise();
            _stateBroker.Initialise();
            
            _levelRegistry.Initialise();
            _saveController.Initialise();
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