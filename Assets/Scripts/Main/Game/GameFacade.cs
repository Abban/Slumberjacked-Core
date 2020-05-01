using UnityEngine;

namespace BBX.Main.Game
{
    /// <summary>
    /// TODO: Make sure this only initialises the controller and runs lifecycle methods
    /// </summary>
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private GameFactory gameFactory = null;

        private GameController _gameController;

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            gameFactory.Initialise(this);
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

        private void Update()
        {
            _gameController.Update();
        }
    }
}