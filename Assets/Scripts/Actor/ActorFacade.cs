using UnityEngine;
using BBX.Actor.Model;
using BBX.Actor.Interfaces;
using BBX.Library;

namespace BBX.Actor
{
    public class ActorFacade : MonoBehaviour, IActor
    {
        public Vector2Int Position => _controller.Position;
        
        [SerializeField] private ActorSettings settings = null;
        [SerializeField] private ActorStatuses statuses = null;

        private ActorFactory _factory;
        private ActorController _controller;
        private ActorModel _model;


        private void Awake()
        {
            _factory = new ActorFactory(
                settings,
                statuses,
                transform.position.ToInt2()
            );
            
            _controller = _factory.Controller;
            _model = _factory.Model;
        }


        private void LateUpdate()
        {
            transform.position = new Vector2(
                _model.Position.x,
                _model.Position.y
            );
        }
        
        
        public PushState Interact(IActorStatuses actorStatuses, Vector2Int direction) => _controller.Interact(actorStatuses, direction);
        public void Push(Vector2Int direction) => _controller.Push(direction);
        public void Initialise() => _controller.Initialise();
        public void Reset() => _controller.Reset();
    }
}