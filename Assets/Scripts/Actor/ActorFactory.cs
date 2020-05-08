using BBX.Actor.Model;
using UnityEngine;

namespace BBX.Actor
{
    public class ActorFactory
    {
        private ActorSettings _settings;
        private Vector2Int _startPosition;

        
        public ActorFactory(
            ActorSettings settings,
            Vector2Int startPosition)
        {
            _settings = settings;
            _startPosition = startPosition;
        }


        private ActorModel _model;
        public ActorModel Model
        {
            get
            {
                if (_model == null)
                {
                    _model = new ActorModel(_startPosition);
                }

                return _model;
            }
        }
        

        private ActorController _controller;
        public ActorController Controller
        {
            get
            {
                if (_controller == null)
                {
                    _controller = new ActorController(
                        _settings,
                        Model
                    );
                }

                return _controller;
            }
        }
    }
}