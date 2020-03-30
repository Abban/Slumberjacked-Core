using System;

namespace BBX.Library.EventManagement
{
    public interface IEventBus
    {
        void Subscribe(string eventName, Action subscriber);
        void Unsubscribe(string eventName, Action subscriber);
        void Fire(string eventName);
    }
}