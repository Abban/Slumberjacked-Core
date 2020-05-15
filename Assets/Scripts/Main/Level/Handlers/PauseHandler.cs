using BBX.Utility;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BBX.Main.Level.Handlers
{
    public class PauseHandler : LevelStateHandler
    {
        public PauseHandler(LevelState levelState, StateBroker stateBroker, EventBus eventBus) : base(levelState, stateBroker, eventBus)
        {
        }


        public void OnPause(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            
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