using BBX.Actor.Interfaces;
using BBX.Actor.Model;
using UnityEngine;

namespace BBX.Actor.Handlers
{
    public class MoveHandler
    {
        private ActorSettings _settings;
        private ActorModel _model;


        public MoveHandler(
            ActorSettings settings,
            ActorModel model)
        {
            _settings = settings;
            _model = model;
        }


        public void OnMove(Vector2Int direction)
        {
            if (!_model.CanMove()) return;
            
            _model.States.MovingState.Value = ActorStates.MovingStates.Moving;
            
            var movePosition = _model.Position + direction;

            if (!_settings.Board.HasWallAt(movePosition))
            {
                var actor = _settings.Board.Get(movePosition);

                if (actor == null)
                {
                    _model.Position += direction;
                }
                else if (actor.Interact(_model.Statuses, direction) == PushState.Pushable)
                {
                    actor.Push(direction);
                    _model.Position += direction;
                }
            }

            _model.States.MovingState.Value = ActorStates.MovingStates.Idle;
        }
    }
}