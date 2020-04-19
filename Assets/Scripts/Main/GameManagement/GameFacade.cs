using UnityEngine;

namespace BBX.Main.GameManagement
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
            _gameController = gameFactory.GameController;
            _gameController.Initialise();
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