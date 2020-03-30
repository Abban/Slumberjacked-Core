using System;
using System.Collections.Generic;
using System.Linq;

namespace BBX.Library.EventManagement
{
    public class EventBus : IEventBus
    {
        private readonly Dictionary<string, Action> _eventDictionary = new Dictionary<string, Action>();

        public void Subscribe(string eventName, Action subscriber)
        {
            if (_eventDictionary.ContainsKey(eventName))
            {
                _eventDictionary[eventName] += subscriber;
            }
            else
            {
                _eventDictionary.Add(eventName, () => { });
            }
        }

        public void Unsubscribe(string eventName, Action subscriber)
        {
            if (!_eventDictionary.ContainsKey(eventName)) return;

            if (!_eventDictionary[eventName].GetInvocationList().Contains(subscriber)) return;

            _eventDictionary[eventName] -= subscriber;
        }

        public void Fire(string eventName)
        {
            _eventDictionary[eventName]();
        }
    }
}