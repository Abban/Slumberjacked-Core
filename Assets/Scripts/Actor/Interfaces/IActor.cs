using UnityEngine;

namespace BBX.Actor.Interfaces
{
    public interface IActor: IInteractable, IPushable, IResetable
    {
        Vector2Int Position { get; }
    }
}