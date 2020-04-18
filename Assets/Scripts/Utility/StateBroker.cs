using BBX.Library.StateObserver;
using UnityEngine;

namespace BBX.Utility
{
    [CreateAssetMenu(fileName = "StateBroker", menuName = "BBX/Utility/State Broker", order = 0)]
    public class StateBroker : ScriptableObject, IStatePropertyBroker, IStateObserverNotifier
    {
        private ObservableStateBroker _stateBroker;

        public void Initialise()
        {
            _stateBroker = new ObservableStateBroker();
        }
        
        public void SetChanged(IObservableStateProperty property)
        {
            _stateBroker.SetChanged(property);
        }

        public void NotifyObservers()
        {
            _stateBroker.NotifyObservers();
        }
    }
}