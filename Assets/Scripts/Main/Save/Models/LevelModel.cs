using System;
using UnityEngine;

namespace BBX.Main.Save.Models
{
    [Serializable]
    public struct LevelModel
    {
        [SerializeField] private string guid;
        [SerializeField] private bool locked;

        public string Guid => guid;
        public bool Locked => locked;

        public LevelModel(string guid, bool locked)
        {
            this.guid = guid;
            this.locked = locked;
        }
    }
}