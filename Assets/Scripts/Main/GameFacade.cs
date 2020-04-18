using UnityEngine;

namespace BBX.Main
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory = null;

        private GameController _gameController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitialiseGame();
        }


        private void InitialiseGame()
        {
            gameFactory.EventBus.Initialise();
            gameFactory.StateBroker.Initialise();
            
            _gameController = gameFactory.GameController;
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