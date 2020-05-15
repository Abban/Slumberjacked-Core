using UnityEngine;
using BBX.Actor.Interfaces;
using BBX.Main.Level.Handlers;
using BBX.Main.Save;
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
        [SerializeField] private SaveController saveController = null;

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
                        _coroutineRunner,
                        new LevelControls(),
                        gameEventBus,
                        StartHandler,
                        PauseHandler,
                        DeathHandler,
                        ResetHandler,
                        FinishHandler
                    );
                }

                return _levelController;
            }
        }

        
        private StartHandler _startHandler;
        private StartHandler StartHandler
        {
            get
            {
                if (_startHandler == null)
                {
                    _startHandler = new StartHandler(
                        levelState,
                        levelStateBroker,
                        gameEventBus,
                        board,
                        _settings,
                        Player
                    );
                }

                return _startHandler;
            }
        }


        private PauseHandler _pauseHandler;
        private PauseHandler PauseHandler
        {
            get
            {
                if (_pauseHandler == null)
                {
                    _pauseHandler = new PauseHandler(
                        levelState,
                        levelStateBroker,
                        gameEventBus
                    );
                }

                return _pauseHandler;
            }
        }


        private DeathHandler _deathHandler;
        private DeathHandler DeathHandler
        {
            get
            {
                if (_deathHandler == null)
                {
                    _deathHandler = new DeathHandler(
                        levelState,
                        levelStateBroker,
                        gameEventBus
                    );
                }

                return _deathHandler;
            }
        }
        
        
        private ResetHandler _resetHandler;
        private ResetHandler ResetHandler
        {
            get
            {
                if (_resetHandler == null)
                {
                    _resetHandler = new ResetHandler(
                        levelState,
                        levelStateBroker,
                        gameEventBus,
                        board
                    );
                }

                return _resetHandler;
            }
        }
        
        
        private FinishHandler _finishHandler;
        private FinishHandler FinishHandler
        {
            get
            {
                if (_finishHandler == null)
                {
                    _finishHandler = new FinishHandler(
                        levelState,
                        levelStateBroker,
                        gameEventBus,
                        _settings,
                        saveController
                    );
                }

                return _finishHandler;
            }
        }


        private IActor _player;
        private IActor Player
        {
            get
            {
                if (_player == null)
                {
                    var player = Instantiate(
                        _settings.PlayerPrefab,
                        _settings.PlayerSpawnPoint
                    );
                    
                    _player = player.GetComponent<IActor>();
                }

                return _player;
            }
        }
    }
}