using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using BBX.Main.Level.Handlers;
using BBX.Utility;

namespace BBX.Main.Level
{
    public class LevelController : LevelControls.ILevelActions
    {
        private MonoBehaviour _coroutineRunner;
        private LevelControls _levelControls;
        private EventBus _gameEventBus;

        private readonly StartHandler _startHandler;
        private readonly PauseHandler _pauseHandler;
        private readonly DeathHandler _deathHandler;
        private readonly ResetHandler _resetHandler;
        private readonly FinishHandler _finishHandler;

        public LevelController(
            MonoBehaviour coroutineRunner,
            LevelControls levelControls,
            EventBus gameEventBus,
            StartHandler startHandler,
            PauseHandler pauseHandler,
            DeathHandler deathHandler,
            ResetHandler resetHandler,
            FinishHandler finishHandler)
        {
            _coroutineRunner = coroutineRunner;
            _levelControls = levelControls;
            _gameEventBus = gameEventBus;
            _startHandler = startHandler;
            _pauseHandler = pauseHandler;
            _deathHandler = deathHandler;
            _resetHandler = resetHandler;
            _finishHandler = finishHandler;
        }

        
        public void Awake()
        {
            _levelControls.Level.SetCallbacks(this);
        }
        
        
        public void Start()
        {
            if (_coroutineRunner != null)
            {
                _coroutineRunner.StartCoroutine(_startHandler.RunStart());
            }
        }


        public void OnEnable()
        {
            _levelControls.Enable();
            _gameEventBus.Subscribe<LevelResetEvent>(_resetHandler.OnReset);
            _gameEventBus.Subscribe<LevelDieEvent>(_deathHandler.OnDeath);
            _gameEventBus.Subscribe<LevelFinishEvent>(_finishHandler.OnFinish);
        }


        public void OnDisable()
        {
            _levelControls.Disable();
            _gameEventBus.Unsubscribe<LevelResetEvent>(_resetHandler.OnReset);
            _gameEventBus.Unsubscribe<LevelDieEvent>(_deathHandler.OnDeath);
            _gameEventBus.Unsubscribe<LevelFinishEvent>(_finishHandler.OnFinish);
        }


        public void OnPause(InputAction.CallbackContext context) => _pauseHandler.OnPause(context);
        public void OnReset(InputAction.CallbackContext context) => _resetHandler.OnReset(context);
    }
}