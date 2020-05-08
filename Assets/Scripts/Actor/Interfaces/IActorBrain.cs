using System;
using UnityEngine;

namespace BBX.Actor.Interfaces
{
    public interface IActorBrain
    {
        /// <summary>
        /// Initialise the brain
        /// </summary>
        void Initialise();
        
        /// <summary>
        /// Start the brain
        /// </summary>
        void Enable();

        /// <summary>
        /// Stop this brain
        /// </summary>
        void Disable();

        /// <summary>
        /// Give the brain a callback to send movement commands to
        /// </summary>
        /// <param name="callback"></param>
        void SetMovementCallback(Action<Vector2Int> callback);
    }
}