using UnityEngine;
using BBX.Main.SceneManagement;
using BBX.Utility;

namespace BBX.Main
{
    public class GameContainer : MonoBehaviour
    {
        [SerializeField] private GameSettings settings = null;
        [SerializeField] private GameObject sceneTransition = null; 
        [SerializeField] private EventBus gameEventBus = null;
        [SerializeField] private GameState gameState = null; 
        [SerializeField] private StateBroker gameStateBroker = null;
        
        private GameController _gameController;
        private SceneController _sceneController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitialiseGame();
        }


        private void InitialiseGame()
        {
            gameEventBus.Initialise();
            gameStateBroker.Initialise();

            _sceneController = new SceneController(
                sceneTransition.GetComponent<ISceneTransition>(),
                gameEventBus
            );
            
            _gameController = new GameController(
                _sceneController,
                settings,
                gameStateBroker,
                gameState,
                gameEventBus
            );
        }


        private void OnEnable()
        {
            _gameController.OnEnable();
        }
        
        private void OnDisable()
        {
            _gameController.OnDisable();
        }
        
        private void Start()
        {
            _gameController.Start();
        }
    }
}