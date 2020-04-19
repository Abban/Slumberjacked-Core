using System.Collections.Generic;
using UnityEngine;
using BBX.Main.SaveManagement.Models;

namespace BBX.Main.LevelSelectManagement
{
    [CreateAssetMenu(fileName = "WorldReference", menuName = "BBX/Level Select/World Reference")]
    public class WorldReference : ScriptableObject
    {
        [SerializeField] private string worldName = string.Empty;
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private bool locked = true;
        [SerializeField] private List<LevelReference> levels = new List<LevelReference>();
        public string Name => worldName;
        public string Guid => guid;
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
        
        
        public World ToWorld()
        {
            if (guid == string.Empty)
            {
                guid = System.Guid.NewGuid().ToString();
            }
            
            return new World(guid, locked);
        }
        
        
        public void FromWorld(World world)
        {
            guid = world.Guid;
            locked = world.Locked;
        }
    }
}