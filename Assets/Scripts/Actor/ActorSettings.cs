using UnityEngine;
using BBX.Actor.Input;
using BBX.Actor.Interfaces;
using BBX.Main.Level;

namespace BBX.Actor
{
    [CreateAssetMenu(fileName = "ActorSettings", menuName = "BBX/Actors/Settings")]
    public class ActorSettings : ScriptableObject
    {
        [SerializeField] private ActorBrain brain = null;
        [SerializeField] private Board board = null;
        [SerializeField] private bool pushable = true;
        
        public IActorBrain Brain => brain;
        public Board Board => board;
        public bool Pushable => pushable;
    }
}