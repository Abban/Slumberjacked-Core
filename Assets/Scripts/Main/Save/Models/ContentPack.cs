using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BBX.Main.Save.Models
{
    [CreateAssetMenu(fileName = "ContentPack", menuName = "BBX/Content/Pack")]
    public class ContentPack : ScriptableObject
    {
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private SaveData saveData = null;
        [SerializeField] private string packName = string.Empty;
        [SerializeField] private string packId = string.Empty;
        [SerializeField] private List<World> worlds = null;

        public string Guid => guid;

        public bool Locked
        {
            get => saveData.Locked;
            set => saveData.Locked = value;
        }
        public string PackName => packName;
        public string PackId => packId;
        
        public List<World> Worlds => worlds;
        public string LastUnlockedWorldGuid => saveData.LastUnlockedWorldGuid;
        public string LastUnlockedLevelGuid => saveData.LastUnlockedLevelGuid;
        
        public SaveData Save
        {
            get
            {
                saveData.Worlds = worlds.Select(world => world.Save).ToList();
                return saveData;
            }
            set
            {
                foreach (var worldData in value.Worlds)
                {
                    var world = worlds.FirstOrDefault(w => w.Guid == worldData.Guid);
                    if (world == null) continue;
                    world.Save = worldData;
                }
                saveData = value;
            }
        }
        
        public void GenerateGuids()
        {
            saveData.GenerateGuid();
            guid = saveData.Guid;
            
            foreach (var world in worlds)
            {
                world.GenerateGuids();
            }
        }


        [Serializable]
        public class SaveData
        {
            [SerializeField] private string guid = string.Empty;
            [SerializeField] private bool locked = true;
            [SerializeField] private string lastUnlockedWorldGuid = string.Empty;
            [SerializeField] private string lastUnlockedLevelGuid = string.Empty;
            [SerializeField] private List<World.SaveData> worlds = null;
            
            public string Guid => guid;
            
            public bool Locked
            {
                get => locked;
                set => locked = value;
            }
            
            public string LastUnlockedWorldGuid
            {
                get => lastUnlockedWorldGuid;
                set => lastUnlockedWorldGuid = value;
            }
            
            public string LastUnlockedLevelGuid
            {
                get => lastUnlockedLevelGuid;
                set => lastUnlockedLevelGuid = value;
            }
            
            public List<World.SaveData> Worlds
            {
                get => worlds;
                set => worlds = value;
            }
            
            public void GenerateGuid()
            {
                guid = System.Guid.NewGuid().ToString();
            }
        }
    }
}