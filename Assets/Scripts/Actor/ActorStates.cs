using BBX.Library.StateObserver;

namespace BBX.Actor
{
    public class ActorStates
    {
        public enum MovingStates
        {
            Idle,
            Moving,
            Pushed
        }
        
        public IObservableStateProperty<MovingStates> MovingState { get; }

        public ActorStates(
            IStatePropertyBroker stateBroker)
        {
            MovingState = new ObservableStateProperty<MovingStates>(stateBroker, MovingStates.Idle);
        }
    }
}