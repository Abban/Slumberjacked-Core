using System;
using BBX.Actor.Input;
using UnityEngine;

namespace BBX.TestSpies
{
    [CreateAssetMenu(fileName = "ActorBrainSpy", menuName = "BBX/Tests/Actor Brain Spy")]
    public class ActorBrainSpy : ActorBrain
    {
        public bool Initialised { get; private set; }
        public bool Enabled { get; private set; }
        public Action<Vector2Int> Callback { get; private set; }


        public override void Initialise()
        {
            Initialised = true;
        }

        public override void Enable()
        {
            Enabled = true;
        }

        public override void Disable()
        {
            Enabled = false;
        }

        public override void SetMovementCallback(Action<Vector2Int> callback)
        {
            Callback = callback;
        }
    }
}