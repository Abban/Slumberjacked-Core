using UnityEngine;

namespace BBX.Actor.Interfaces
{
    public enum PushState
    {
        Pushable,
        Static,
        Blocked
    }
    
    public interface IInteractable
    {
        PushState Interact(Vector2Int direction);
    }
}