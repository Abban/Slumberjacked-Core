using System.Collections.Generic;
using UnityEngine;

namespace BBX.Main.Game.Structure
{
    [CreateAssetMenu(fileName = "WorldReference", menuName = "BBX/Structure/World Reference")]
    public class WorldReference : ScriptableObject
    {
        [SerializeField] private string worldName = string.Empty;
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private bool locked = true;
        [SerializeField] private List<LevelReference> levels = new List<LevelReference>();
        public string Name => worldName;
        public string Guid {
            get
            {
                if (guid == string.Empty)
                {
                    guid = System.Guid.NewGuid().ToString();
                }

                return guid;
            }
        }
        
        public bool Locked => locked;
        public List<LevelReference> Levels => levels;

        public void SetLocked(bool toLocked)
        {
            locked = toLocked;
        }

        public void Unlock()
        {
            SetLocked(false);
        }
    }
}