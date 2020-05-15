using System.Collections;
using BBX.Actor.Interfaces;
using UnityEngine;
using BBX.Utility;

namespace BBX.Main.Level.Handlers
{
    public class StartHandler : LevelStateHandler
    {
        private Board _board;
        private LevelSettings _settings;
        private IActor _player;
        
        public StartHandler(
            LevelState levelState,
            StateBroker stateBroker,
            EventBus eventBus,
            Board board,
            LevelSettings settings,
            IActor player) : base(levelState, stateBroker, eventBus)
        {
            _board = board;
            _settings = settings;
            _player = player;
        }
        


        public IEnumerator RunStart()
        {
            var actors = _settings.Actors;
            actors.Add(_player);
            _board.Initialise(actors);
            
            _eventBus.Fire(new LevelInitialisedEvent());
            yield return new WaitForSeconds(1);
            _levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
            _stateBroker.NotifyObservers();
        }
    }
}