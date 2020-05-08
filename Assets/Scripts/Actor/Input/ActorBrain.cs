using System;
using BBX.Actor.Interfaces;
using UnityEngine;

namespace BBX.Actor.Input
{
    public abstract class ActorBrain : ScriptableObject, IActorBrain
    {
        public abstract void Initialise();
        public abstract void Enable();
        public abstract void Disable();
        public abstract void SetMovementCallback(Action<Vector2Int> callback);
    }
}