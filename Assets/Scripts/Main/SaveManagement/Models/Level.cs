using System;
using UnityEngine;

namespace BBX.Main.SaveManagement.Models
{
    [Serializable]
    public struct Level
    {
        [SerializeField] private string guid;
        [SerializeField] private bool locked;

        public string Guid => guid;
        public bool Locked => locked;

        public Level(string guid, bool locked)
        {
            this.guid = guid.ToString();
            this.locked = locked;
        }
    }
}