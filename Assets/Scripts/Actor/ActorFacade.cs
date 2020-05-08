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
        
        private ActorFactory _factory;
        private ActorController _controller;
        private ActorModel _model;


        private void Awake()
        {
            _factory = new ActorFactory(
                settings,
                transform.position.ToInt2()
            );
            
            _controller = _factory.Controller;
            _model = _factory.Model;
        }


        private void Start()
        {
            _controller.Start();
        }

        
        private void LateUpdate()
        {
            transform.position = new Vector2(
                _model.Position.x,
                _model.Position.y
            );
        }


        // TODO: Parcel these out into handlers
        public PushState Interact(Vector2Int direction) => _controller.Interact(direction);
        public void Push(Vector2Int direction) => _controller.Push(direction);
        public void Reset() => _controller.Reset();
    }
}