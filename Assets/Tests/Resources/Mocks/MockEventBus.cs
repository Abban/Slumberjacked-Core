using System;
using BBX.Library.EventManagement;

namespace BBX.TestMocks
{
    public class MockEventBus : IEventBus
    {
        public void Subscribe<T>(Action<T> subscriber) where T : IEvent
        {
        }

        public void Unsubscribe<T>(Action<T> subscriber) where T : IEvent
        {
        }

        public void Fire<T>(T payload) where T : IEvent
        {
        }
    }
}