using UnityEngine;
using BBX.Main.SceneManagement;
using BBX.Utility;

namespace BBX.Main
{
    [CreateAssetMenu(fileName = "GameFactory", menuName = "BBX/Game/Factory")]
    public class GameFactory : ScriptableObject
    {
        [SerializeField] private GameSettings settings = null;
        [SerializeField] private GameObject sceneTransitionPrefab = null; 
        [SerializeField] private EventBus gameEventBus = null;
        [SerializeField] private GameState gameState = null; 
        [SerializeField] private StateBroker gameStateBroker = null;

        public EventBus EventBus => gameEventBus;
        public StateBroker StateBroker => gameStateBroker;

        private ISceneTransition _sceneTransition;

        public ISceneTransition SceneTransition {
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

        private GameController _gameController;
        public GameController GameController {
            get
            {
                if (_gameController == null)
                {
                    _gameController = new GameController(
                        SceneController,
                        settings,
                        gameStateBroker,
                        gameState,
                        gameEventBus
                    );
                }

                return _gameController;
            }
        }
        
        
        private SceneController _sceneController;
        public SceneController SceneController
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
    }
}