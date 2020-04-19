using UnityEngine;
using BBX.Main.LevelSelectManagement;
using BBX.Main.SaveManagement;
using BBX.Main.SaveManagement.Interfaces;
using BBX.Main.SaveManagement.Models;
using BBX.Main.SceneManagement;
using BBX.Utility;

namespace BBX.Main.GameManagement
{
    [CreateAssetMenu(fileName = "GameFactory", menuName = "BBX/Game/Factory")]
    public class GameFactory : ScriptableObject
    {
        [SerializeField] private GameSettings settings = null;
        [SerializeField] private GameObject sceneTransitionPrefab = null; 
        [SerializeField] private EventBus gameEventBus = null;
        [SerializeField] private GameState gameState = null; 
        [SerializeField] private StateBroker gameStateBroker = null;
        [SerializeField] private LevelRegistry levelRegistry = null;
        [SerializeField] private SaveController.Components saveComponents = null;

        private GameController _gameController;
        public GameController GameController {
            get
            {
                if (_gameController == null)
                {
                    _gameController = new GameController(
                        SceneController,
                        SaveController,
                        settings,
                        gameStateBroker,
                        gameState,
                        gameEventBus,
                        levelRegistry
                    );
                }

                return _gameController;
            }
        }


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

        private SceneController _sceneController;

        private SceneController SceneController
        {
            get
            {
                if (_sceneController == null)
                {
                    _sceneController = new SceneController(
                        SceneTransition,
                        gameEventBus
                    );
                }

                return _sceneController;
            }
        }


        private IDataRepository<Game> _dataRepository;
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
                        saveComponents,
                        gameEventBus,
                        _dataRepository,
                        levelRegistry.GetWorlds(),
                        levelRegistry.GetLevels());
                }

                return _saveController;
            }
        }
    }
}