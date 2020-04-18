using System;
using UnityEngine;
using BBX.Library.EventManagement;

namespace BBX.Utility
{
    [CreateAssetMenu(fileName = "EventBus", menuName = "BBX/Utility/Event Bus")]
    public class EventBus : ScriptableObject, IEventBus
    {
        private IEventBus _eventBus;

        public void Initialise()
        {
            _eventBus = new BBX.Library.EventManagement.EventBus();
        }
        
        public void Subscribe<T>(Action<T> subscriber) where T : IEvent
        {
            _eventBus.Subscribe(subscriber);
        }

        public void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
        {
            _eventBus.Unsubscribe(subscriber);
        }

        public void Fire<T>(T payload) where T : IEvent
        {
            _eventBus.Fire(payload);
        }
    }
}