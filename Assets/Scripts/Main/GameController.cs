using BBX.Main.SceneManagement;

namespace BBX.Main
{
    public class GameController
    {
        private SceneController _sceneController;
        private GameSettings _settings;
        
        public GameController(
            SceneController sceneController,
            GameSettings settings)
        {
            _sceneController = sceneController; 
            _settings = settings;
        }

        public void Start()
        {
            if (_sceneController.CurrentScene == null)
            {
                _sceneController.LoadScene(_settings.Scenes.DefaultScene);
            }
        }
    }
}