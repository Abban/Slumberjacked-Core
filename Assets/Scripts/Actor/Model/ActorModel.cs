using UnityEngine;

namespace Actor.Model
{
    public class ActorModel
    {
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