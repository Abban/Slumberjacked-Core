using BBX.Actor.Interfaces;
using BBX.Actor.Model;
using UnityEngine;

namespace BBX.Actor.Handlers
{
    /// <summary>
    /// This is called when this actor is pushed
    /// </summary>
    public class PushHandler : IPushable
    {
        private ActorModel _model;
        private ActorSettings _settings;

        public PushHandler(
            ActorModel model,
            ActorSettings settings)
        {
            _model = model;
            _settings = settings;
        }
        
        public void Push(Vector2Int direction)
        {
            _model.States.MovingState.Value = ActorStates.MovingStates.Pushed;
            
            var movePosition = _model.Position + direction;

            var actor = _settings.Board.Get(movePosition);
            actor?.Push(direction);

            _model.Position += direction;
            
            _model.States.MovingState.Value = ActorStates.MovingStates.Idle;
        }
    }
}