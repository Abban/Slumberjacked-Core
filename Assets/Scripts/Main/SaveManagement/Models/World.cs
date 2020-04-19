using System;
using UnityEngine;

namespace BBX.Main.SaveManagement.Models
{
    [Serializable]
    public struct World
    {
        [SerializeField] private string guid;
        [SerializeField] private bool locked;

        public string Guid => guid;
        public bool Locked => locked;

        public World(string guid, bool locked)
        {
            this.guid = guid;
            this.locked = locked;
        }
    }
}