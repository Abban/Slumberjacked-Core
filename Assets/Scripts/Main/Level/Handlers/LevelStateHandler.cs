using BBX.Utility;

namespace BBX.Main.Level.Handlers
{
    public abstract class LevelStateHandler
    {
        protected readonly LevelState _levelState;
        protected readonly StateBroker _stateBroker;
        protected readonly EventBus _eventBus;

        
        protected LevelStateHandler(
            LevelState levelState,
            StateBroker stateBroker,
            EventBus eventBus)
        {
            _levelState = levelState;
            _stateBroker = stateBroker;
            _eventBus = eventBus;
        }
    }
}