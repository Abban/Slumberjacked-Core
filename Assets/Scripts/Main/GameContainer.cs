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

        private void Awake()
        {
            DontDestroyOnLoad(gameObject);
            InitialiseGame();
        }


        private void InitialiseGame()
        {
            _sceneController = new SceneController(
                settings.Scenes,
                sceneTransition.GetComponent<ISceneTransition>()
            );
            
            _gameController = new GameController(
                _sceneController,
                settings
            );
        }


        private void Start()
        {
            _gameController.Start();
        }
    }
}