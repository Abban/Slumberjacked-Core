using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using BBX.Utility;

namespace BBX.Main.Level
{
    public class LevelController : LevelControls.ILevelActions
    {
        private LevelState _levelState;
        private MonoBehaviour _coroutineRunner;
        private StateBroker _stateBroker;
        private Board _board;
        private LevelControls _levelControls;
        private EventBus _gameEventBus;

        public LevelController(
            LevelState levelState,
            MonoBehaviour coroutineRunner,
            StateBroker stateBroker,
            Board board,
            LevelControls levelControls,
            EventBus gameEventBus)
        {
            _levelState = levelState;
            _coroutineRunner = coroutineRunner;
            _stateBroker = stateBroker;
            _board = board;
            _levelControls = levelControls;
            _gameEventBus = gameEventBus;
        }

        
        public void Awake()
        {
            _board.Initialise(new List<Vector2Int>());
            _levelControls.Level.SetCallbacks(this);
        }
        
        
        public void Start()
        {
            _gameEventBus.Fire(new LevelStartEvent());
            _coroutineRunner.StartCoroutine(RunStart());
        }

        
        /// <summary>
        /// TODO: Put this into a Start Handler
        /// </summary>
        /// <returns></returns>
        private IEnumerator RunStart()
        {
            yield return new WaitForSeconds(1);
            _levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
            _stateBroker.NotifyObservers();
        }

        
        public void OnEnable()
        {
            _levelControls.Enable();
        }


        public void OnDisable()
        {
            _levelControls.Disable();
        }
        
        
        public void OnPause(InputAction.CallbackContext context)
        {
            switch (_levelState.GameplayState.Value)
            {
                case LevelState.GameplayStates.Playing:
                    Time.timeScale = 0;
                    _levelState.GameplayState.Value = LevelState.GameplayStates.Paused;
                    _stateBroker.NotifyObservers();
                    break;
                case LevelState.GameplayStates.Paused:
                    Time.timeScale = 1;
                    _levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
                    _stateBroker.NotifyObservers();
                    break;
            }
        }
    }
}