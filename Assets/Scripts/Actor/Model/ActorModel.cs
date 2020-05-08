using UnityEngine;

namespace BBX.Actor.Model
{
    public class ActorModel
    {
        public Vector2Int StartPosition { get; }

        public ActorModel(Vector2Int startPosition)
        {
            StartPosition = startPosition;
            Position = startPosition;
        }
        
        
        private Vector2Int _position;
        public Vector2Int Position
        {
            get => _position;
            set
            {
                // Validate with registry?
                _position = value;
            }
        }
    }
}