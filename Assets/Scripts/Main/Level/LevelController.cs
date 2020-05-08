using System.Collections.Generic;
using BBX.Utility;
using UnityEngine;

namespace BBX.Main.Level
{
    public class LevelController
    {
        private LevelState _levelState;
        private StateBroker _stateBroker;
        private Board _board;

        public LevelController(
            LevelState levelState,
            StateBroker stateBroker,
            Board board)
        {
            _levelState = levelState;
            _stateBroker = stateBroker;
            _board = board;
        }


        public void Awake()
        {
            _board.Initialise(new List<Vector2Int>());
        }
        
        
        public void Start()
        {
            _levelState.GameplayState.Value = LevelState.GameplayStates.Playing;
            _stateBroker.NotifyObservers();
        }
    }
}