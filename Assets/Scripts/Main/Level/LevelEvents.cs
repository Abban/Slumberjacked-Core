using BBX.Library.EventManagement;

namespace BBX.Main.Level
{
    public class LevelInitialisedEvent : IEvent
    {
        public LevelInitialisedEvent()
        {
        }
    }
    
    
    public class LevelResetEvent : IEvent
    {
        public LevelResetEvent()
        {
        }
    }
    
    
    public class LevelDieEvent : IEvent
    {
        public LevelDieEvent()
        {
        }
    }
    
    
    public class LevelFinishEvent : IEvent
    {
        public LevelFinishEvent()
        {
        }
    }
}