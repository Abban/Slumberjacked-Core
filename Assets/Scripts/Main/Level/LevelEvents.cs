using BBX.Library.EventManagement;

namespace BBX.Main.Level
{
    public class LevelStartEvent : IEvent
    {
        public Board Board { get; private set; }

        public LevelStartEvent(Board board)
        {
            Board = board;
        }
    }
}