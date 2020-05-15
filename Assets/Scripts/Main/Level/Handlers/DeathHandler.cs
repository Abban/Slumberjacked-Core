using BBX.Utility;

namespace BBX.Main.Level.Handlers
{
    public class DeathHandler : LevelStateHandler
    {
        public DeathHandler(
            LevelState levelState,
            StateBroker stateBroker,
            EventBus eventBus) : base(levelState, stateBroker, eventBus)
        {
        }


        public void OnDeath(LevelDieEvent dieEvent)
        {
            _levelState.GameplayState.Value = LevelState.GameplayStates.Died;
            _stateBroker.NotifyObservers();
        }
    }
}