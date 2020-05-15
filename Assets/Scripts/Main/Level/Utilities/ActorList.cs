using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BBX.Actor;
using BBX.Actor.Interfaces;

namespace BBX.Main.Level.Utilities
{
    public class ActorList : MonoBehaviour
    {
        [SerializeField] private List<ActorFacade> actors = null;
        public List<IActor> Actors => actors.ToList<IActor>();

        public void ImportChildren()
        {
            var actorArray = GetComponentsInChildren<ActorFacade>();
            actors = actorArray.ToList();
        }
    }
}