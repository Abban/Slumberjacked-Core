using System;
using UnityEngine;
using BBX.Actor.Handlers;
using BBX.Actor.Model;
using BBX.Actor.Interfaces;

namespace BBX.Actor
{
    public class ActorController : IDisposable, IActor
    {
        public Vector2Int Position => _model.Position;

        private readonly ActorSettings _settings;
        private readonly ActorModel _model;
        private readonly MoveHandler _moveHandler;
        private readonly InteractHandler _interactHandler;
        private readonly PushHandler _pushHandler;
        private readonly ResetHandler _resetHandler;

        public ActorController(
            ActorSettings settings,
            ActorModel model,
            MoveHandler moveHandler,
            InteractHandler interactHandler,
            PushHandler pushHandler,
            ResetHandler resetHandler)
        {
            _settings = settings;
            _model = model;
            _moveHandler = moveHandler;
            _interactHandler = interactHandler;
            _pushHandler = pushHandler;
            _resetHandler = resetHandler;
        }


        public void Initialise() 
        {
            _settings.Brain.Initialise();
            _settings.Brain.SetMovementCallback(_moveHandler.OnMove);
            _settings.Brain.Enable();
        }


        public void Dispose()
        {
            _settings.Brain.Disable();
        }

        
        public PushState Interact(IActorStatuses statuses, Vector2Int direction) => _interactHandler.Interact(statuses, direction);
        public void Push(Vector2Int direction) => _pushHandler.Push(direction);

        public void Reset() => _resetHandler.Reset();
    }
}