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
        private List<Vector2Int> _static;

        
        public void Initialise(List<IActor> actors)
        {
            _actors = new BoardRegistry<IActor>(actors);
            _static = new List<Vector2Int>();

            foreach (var actor in _actors.Items)
            {
                actor.Initialise();
            }
        }
        
        
        public void Initialise(List<IActor> actors, List<Vector2Int> walls)
        {
            _actors = new BoardRegistry<IActor>(actors);
            _static = walls;
        }


        public void Add(IActor actor)
        {
            if (_static.Contains(actor.Position))
            {
                ExceptionLogger.Exception($"Tried to add an actor {actor} at a position where a wall exists ({actor.Position})");
            }
            
            _actors.Add(actor);
        }


        public void ResetActors()
        {
            foreach (var actor in _actors.Items)
            {
                actor.Reset();
            }
        }


        public IActor Get(Vector2Int at)
        {
            return _actors.Get(at);
        }


        public bool HasWallAt(Vector2Int at)
        {
            return _static.Contains(at);
        }
        
        
        public bool Exists(IActor actor)
        {
            return _actors.Exists(actor);
        }
    }
}