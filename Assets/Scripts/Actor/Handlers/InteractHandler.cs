using BBX.Actor.Interfaces;
using BBX.Actor.Model;
using UnityEngine;

namespace BBX.Actor.Handlers
{
    /// <summary>
    /// Happens before a push, this is when an actor interacts with another one
    /// </summary>
    public class InteractHandler : IInteractable
    {
        private ActorModel _model;
        private ActorSettings _settings;


        public InteractHandler(
            ActorModel model,
            ActorSettings settings)
        {
            _model = model;
            _settings = settings;
        }
        
        
        public PushState Interact(IActorStatuses statuses, Vector2Int direction)
        {
            if (!_settings.Pushable)
            {
                return PushState.Static;
            }
            
            var movePosition = _model.Position + direction;
            
            if (_settings.Board.HasWallAt(movePosition))
            {
                return PushState.Blocked;
            }

            var actor = _settings.Board.Get(movePosition);

            if (actor == null)
            {
                return PushState.Pushable;
            }

            return actor.Interact(_model.Statuses, direction);
        }
    }
}