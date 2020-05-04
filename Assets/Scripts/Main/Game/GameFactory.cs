using UnityEngine;
using BBX.Main.Save;
using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;
using BBX.Main.Scene;
using BBX.Utility;

namespace BBX.Main.Game
{
    [CreateAssetMenu(fileName = "GameFactory", menuName = "BBX/Game/Factory")]
    public class GameFactory : ScriptableObject
    {
        [SerializeField] private GameSettings settings = null;
        [SerializeField] private SaveGame saveGame = null;
        [SerializeField] private GameObject sceneTransitionPrefab = null; 
        [SerializeField] private EventBus gameEventBus = null;
        [SerializeField] private GameState gameState = null; 
        [SerializeField] private StateBroker gameStateBroker = null;

        private MonoBehaviour _coroutineRunner;


        public void Initialise(MonoBehaviour coroutineRunner)
        {
            _coroutineRunner = coroutineRunner;
            
            gameState.Initialise(gameStateBroker);
            gameEventBus.Initialise();
            gameStateBroker.Initialise();
            
            SaveController.Initialise();
        }

        
        /// <summary>
        /// This runs the game
        /// </summary>
        private GameController _gameController;
        public GameController GameController {
            get
            {
                if (_gameController == null)
                {
                    _gameController = new GameController(
                        gameStateBroker,
                        gameEventBus,
                        SceneController,
                        settings,
                        gameState,
                        _coroutineRunner
                    );
                }

                return _gameController;
            }
        }

        
        /// <summary>
        /// This is the UI loading display
        /// </summary>
        private ISceneTransition _sceneTransition;
        public ISceneTransition SceneTransition
        {
            get
            {
                if (_sceneTransition == null)
                {
                    var sceneTransition = Instantiate(sceneTransitionPrefab);
                    _sceneTransition = sceneTransition.GetComponent<ISceneTransition>();
                }

                return _sceneTransition;
            }
        }

        
        /// <summary>
        /// This handles loading the main scenes
        /// </summary>
        private SceneController _sceneController;
        private SceneController SceneController
        {
            get
            {
                if (_sceneController == null)
                {
                    _sceneController = new SceneController(
                        SceneTransition,
                        gameState,
                        gameEventBus
                    );
                }

                return _sceneController;
            }
        }

        
        /// <summary>
        /// This handles save games
        /// </summary>
        private IDataRepository<SaveGame.SaveData> _dataRepository;
        private SaveController _saveController;
        private SaveController SaveController
        {
            get
            {
                if (_dataRepository == null)
                {
                    _dataRepository = new SaveDataRepository();
                }
                
                if (_saveController == null)
                {
                    _saveController = new SaveController(
                        saveGame,
                        gameEventBus,
                        _dataRepository
                    );
                }

                return _saveController;
            }
        }
    }
}