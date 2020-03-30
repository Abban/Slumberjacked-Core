using BBX.Library.EventManagement;
using UnityEngine;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    public class GameContainer : MonoBehaviour
    {
        [SerializeField] private GameSettings settings = null;
        [SerializeField] private GameObject sceneTransition = null; 
        
        private GameController _gameController;
        private SceneController _sceneController;
        private EventBus _gameEventBus;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitialiseGame();
        }


        private void InitialiseGame()
        {
            _gameEventBus = new EventBus();

            _sceneController = new SceneController(
                settings.Scenes,
                sceneTransition.GetComponent<ISceneTransition>(),
                _gameEventBus
            );
            
            _gameController = new GameController(
                _sceneController,
                settings,
                _gameEventBus
            );
        }


        private void InitialiseGameState()
        {
            
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