using System;
using BBX.Actor.Model;
using BBX.Actor.Interfaces;
using UnityEngine;

namespace BBX.Actor
{
    public class ActorController: IDisposable, IActor
    {
        public Vector2Int Position => _model.Position;
        
        private readonly ActorSettings _settings;
        private readonly ActorModel _model;
        
        public ActorController(
            ActorSettings settings,
            ActorModel model)
        {
            _settings = settings;
            _model = model;
        }


        public void Start()
        {
            _settings.Brain.Initialise();
            _settings.Brain.SetMovementCallback(OnMove);
            _settings.Brain.Enable();
            _settings.Board.Add(this, _model.StartPosition);
        }

        
        public void Dispose()
        {
            _settings.Brain.Disable();
        }


        /// <summary>
        /// When a brain tries to move an actor
        /// TODO: This needs to be business logic
        ///
        /// 1. Look for a wall
        /// 2. Look for an actor
        /// 3. Check actor is pushable
        /// 4. Perform push
        /// 5. Update own position
        /// 
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        private void OnMove(Vector2Int direction)
        {
            var movePosition = Position + direction;

            if (_settings.Board.HasWallAt(movePosition))
            {
                return;
            }

            var actor = _settings.Board.Get(movePosition);

            if (actor == null)
            {
                _settings.Board.Move(this, movePosition);
                _model.Position += direction;
                return;
            }

            if (actor.Interact(direction) == PushState.Pushable)
            {
                Push(direction);
            }
        }

        
        /// <summary>
        /// Happens before a push, this is when an actor interacts with another one
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public PushState Interact(Vector2Int direction)
        {
            if (!_settings.Pushable)
            {
                return PushState.Static;
            }
            
            var movePosition = Position + direction;
            
            if (_settings.Board.HasWallAt(movePosition))
            {
                return PushState.Blocked;
            }

            var actor = _settings.Board.Get(movePosition);

            if (actor == null)
            {
                return PushState.Pushable;
            }

            return actor.Interact(direction);
        }

        
        /// <summary>
        /// This is called when this actor is pushed
        /// </summary>
        /// <param name="direction"></param>
        public void Push(Vector2Int direction)
        {
            var movePosition = Position + direction;
            
            var actor = _settings.Board.Get(movePosition);
            actor?.Push(direction);

            _settings.Board.Move(this, Position + direction);
            _model.Position += direction;
        }

        
        /// <summary>
        /// Reset this actor
        /// </summary>
        public void Reset()
        {
            _model.Position = _model.StartPosition;
            _settings.Board.Add(this, _model.StartPosition);
        }
    }
}