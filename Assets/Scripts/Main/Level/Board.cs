using System.Collections.Generic;
using UnityEngine;
using BBX.Actor.Interfaces;
using BBX.Main.Level.Utilities;
using BBX.Utility;

namespace BBX.Main.Level
{
    [CreateAssetMenu(fileName = "Board", menuName = "BBX/Level/Board")]
    public class Board : ScriptableObject
    {
        private BoardRegistry<IActor> _actors;
        private List<Vector2Int> _walls;

        
        public void Initialise()
        {
            _walls = new List<Vector2Int>();
            _actors = new BoardRegistry<IActor>();
        }
        
        
        public void Initialise(List<Vector2Int> walls)
        {
            _walls = walls;
            _actors = new BoardRegistry<IActor>();
        }


        public void Add(IActor actor)
        {
            if (_walls.Contains(actor.Position))
            {
                ExceptionLogger.Exception($"Tried to add an actor {actor} at a position where a wall exists ({actor.Position})");
            }
            
            _actors.Add(actor);
        }


        public IActor Get(Vector2Int at)
        {
            return _actors.Get(at);
        }


        public bool HasWallAt(Vector2Int at)
        {
            return _walls.Contains(at);
        }
        
        
        public bool Exists(IActor actor)
        {
            return _actors.Exists(actor);
        }
    }
}