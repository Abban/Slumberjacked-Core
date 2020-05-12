using System;
using BBX.Actor.Interfaces;
using UnityEngine;

namespace BBX.Actor
{
    [Serializable]
    public class ActorStatuses : IActorStatuses
    {
        [SerializeField] private bool burning = false;

        public bool Burning => burning;
    }
}