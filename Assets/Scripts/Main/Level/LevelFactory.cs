using UnityEngine;
using BBX.Actor.Interfaces;
using BBX.Utility;

namespace BBX.Main.Level
{
    [CreateAssetMenu(fileName = "LevelFactory", menuName = "BBX/Level/Factory")]
    public class LevelFactory : ScriptableObject
    {
        [SerializeField] private LevelState levelState = null;
        [SerializeField] private StateBroker levelStateBroker = null;
        [SerializeField] private Board board = null;
        [SerializeField] private EventBus gameEventBus = null;

        private LevelSettings _settings;
        private MonoBehaviour _coroutineRunner;

        public void Initialise(
            LevelSettings settings,
            MonoBehaviour coroutineRunner)
        {
            _settings = settings;
            _coroutineRunner = coroutineRunner;
            
            levelState.Initialise(levelStateBroker);
            levelStateBroker.Initialise();
        }


        private LevelController _levelController;

        public LevelController LevelController
        {
            get
            {
                if (_levelController == null)
                {
                    _levelController = new LevelController(
                        levelState,
                        _coroutineRunner,
                        levelStateBroker,
                        board,
                        new LevelControls(),
                        gameEventBus
                    );
                }

                return _levelController;
            }
        }


        private IActor _player;

        public IActor Player
        {
            get
            {
                if (_player == null)
                {
                    var player = Instantiate(_settings.PlayerPrefab, _settings.PlayerSpawnPoint);
                    _player = player.GetComponent<IActor>();
                }

                return _player;
            }
        }
    }
}