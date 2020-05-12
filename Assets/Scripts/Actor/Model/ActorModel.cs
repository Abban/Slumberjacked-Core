using UnityEngine;
using BBX.Actor.Interfaces;
using BBX.Main.Level;

namespace BBX.Actor.Model
{
    public class ActorModel
    {
        public Vector2Int StartPosition { get; }
        public ActorStates States { get; }
        public IActorStatuses Statuses { get; }

        public LevelState LevelState { get; }

        public ActorModel(
            Vector2Int startPosition,
            ActorStates states,
            IActorStatuses statuses,
            LevelState levelState)
        {
            StartPosition = startPosition;
            Position = startPosition;
            States = states;
            Statuses = statuses;
            LevelState = levelState;
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


        public bool CanMove()
        {
            if (LevelState.GameplayState.Value != LevelState.GameplayStates.Playing)
            {
                return false;
            }

            return States.MovingState.Value == ActorStates.MovingStates.Idle;
        }
    }
}