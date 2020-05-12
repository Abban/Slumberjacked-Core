using UnityEngine;
using BBX.Actor.Handlers;
using BBX.Actor.Interfaces;
using BBX.Actor.Model;
using BBX.Library.StateObserver;

namespace BBX.Actor
{
    public class ActorFactory
    {
        private readonly ActorSettings _settings;
        private readonly IActorStatuses _statuses;
        private readonly Vector2Int _startPosition;

        
        public ActorFactory(
            ActorSettings settings,
            IActorStatuses statuses,
            Vector2Int startPosition)
        {
            _settings = settings;
            _statuses = statuses;
            _startPosition = startPosition;
        }


        private ActorModel _model;
        public ActorModel Model
        {
            get
            {
                if (_model == null)
                {
                    _model = new ActorModel(
                        _startPosition,
                        States,
                        _statuses,
                        _settings.LevelState
                    );
                }

                return _model;
            }
        }


        private ActorStates _states;
        private ActorStates States
        {
            get
            {
                if (_states == null)
                {
                    _states = new ActorStates(new ObservableStateBroker());
                }

                return _states;
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
                        Model,
                        MoveHandler,
                        InteractHandler,
                        PushHandler,
                        ResetHandler
                    );
                }

                return _controller;
            }
        }


        private MoveHandler _moveHandler;

        private MoveHandler MoveHandler
        {
            get
            {
                if (_moveHandler == null)
                {
                    _moveHandler = new MoveHandler(
                        _settings,
                        _model
                    );
                }

                return _moveHandler;
            }
        }

        
        private InteractHandler _interactHandler;
        private InteractHandler InteractHandler
        {
            get
            {
                if (_interactHandler == null)
                {
                    _interactHandler = new InteractHandler(
                        _model,
                        _settings
                    );
                }

                return _interactHandler;
            }
        }

        
        private PushHandler _pushHandler;
        private PushHandler PushHandler
        {
            get
            {
                if (_pushHandler == null)
                {
                    _pushHandler = new PushHandler(
                        _model,
                        _settings
                    );
                }

                return _pushHandler;
            }
        }


        private ResetHandler _resetHandler;
        private ResetHandler ResetHandler
        {
            get
            {
                if (_resetHandler == null)
                {
                    _resetHandler = new ResetHandler(_model);
                }

                return _resetHandler;
            }
        }
    }
}