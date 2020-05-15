using BBX.Utility;
using UnityEngine.InputSystem;

namespace BBX.Main.Level.Handlers
{
    public class ResetHandler : LevelStateHandler
    {
        private Board _board;
        
        
        public ResetHandler(
            LevelState levelState,
            StateBroker stateBroker,
            EventBus eventBus,
            Board board) : base(levelState, stateBroker, eventBus)
        {
            _board = board;
        }


        public void OnReset(LevelResetEvent levelResetEvent)
        {
            ResetLevel();
        }
        

        public void OnReset(InputAction.CallbackContext context)
        {
            if (!context.performed) return;
            ResetLevel();
        }


        private void ResetLevel()
        {
            _levelState.GameplayState.Value = LevelState.GameplayStates.Resetting;
            _stateBroker.NotifyObservers();
            
            _board.ResetActors();
            
            _levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
            _stateBroker.NotifyObservers();
        }
    }
}