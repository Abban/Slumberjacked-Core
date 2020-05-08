using System;
using BBX.Library;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BBX.Actor.Input
{
    [CreateAssetMenu(fileName = "PlayerInputBrain", menuName = "BBX/Actors/Player Input Brain")]
    public class PlayerInputBrain : ActorBrain, PlayerControls.IPlayerActions
    {
        private PlayerControls _playerControls;
        private Action<Vector2Int> _callback;

        public override void Initialise()
        {
            _playerControls = new PlayerControls();
            _playerControls.Player.SetCallbacks(this);
        }

        
        public override void Enable()
        {
            _playerControls.Enable();
        }

        
        public override void Disable()
        {
            _playerControls.Disable();
        }

        
        public override void SetMovementCallback(Action<Vector2Int> callback)
        {
            _callback = callback;
        }

        
        public void OnMove(InputAction.CallbackContext context)
        {
            if (!context.performed) return;

            var direction = context.ReadValue<Vector2>();

            _callback?.Invoke(direction.ToInt2());
        }
    }
}