using BBX.Main.Save;
using BBX.Utility;

namespace BBX.Main.Level.Handlers
{
    public class FinishHandler : LevelStateHandler
    {
        private LevelSettings _settings;
        private SaveController _saveController;
        
        public FinishHandler(
            LevelState levelState,
            StateBroker stateBroker,
            EventBus eventBus,
            LevelSettings settings,
            SaveController saveController) : base(levelState, stateBroker, eventBus)
        {
            _settings = settings;
            _saveController = saveController;
        }


        public void OnFinish(LevelFinishEvent levelFinishEvent)
        {
            if (_settings.Level.LevelToUnlock != null)
            {
                _settings.Level.LevelToUnlock.Locked = false;
            }
            
            if (_settings.Level.WorldToUnlock != null)
            {
                _settings.Level.WorldToUnlock.Locked = false;
            }
            
            _saveController.Save();
            _levelState.GameplayState.Value = LevelState.GameplayStates.Finishing;
            _stateBroker.NotifyObservers();
        }
    }
}