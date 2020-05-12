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
        PushState Interact(IActorStatuses statuses, Vector2Int direction);
    }
}