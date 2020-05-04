using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BBX.Main.Save.Models
{
    [CreateAssetMenu(fileName = "World", menuName = "BBX/Content/World")]
    public class World : ScriptableObject
    {
        [SerializeField] private SaveData saveData = null;
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private List<Level> levels = null;
        
        public SaveData Save
        {
            get
            {
                saveData.Levels = Levels.Select(level => level.Save).ToList();
                return saveData;
            }
            set
            {
                foreach (var levelData in value.Levels)
                {
                    var level = levels.FirstOrDefault(l => l.Guid == levelData.Guid);
                    if (level == null) continue;
                    level.Save = levelData;
                }
                saveData = value;
            }
        }
        
        public string Guid => guid;
        public bool Locked => saveData.Locked;
        public List<Level> Levels => levels;
        
        public void GenerateGuids()
        {
            saveData.GenerateGuid();
            guid = saveData.Guid;

            foreach (var level in levels)
            {
                level.GenerateGuid();
            }
        }

        
        [Serializable]
        public class SaveData
        {
            [SerializeField] private bool locked = true;
            [SerializeField] private string guid = string.Empty;
            [SerializeField] private List<Level.SaveData> levels = null;

            public bool Locked
            {
                get => locked;
                set => locked = value;
            }
            
            public string Guid => guid;
            
            public List<Level.SaveData> Levels
            {
                get => levels;
                set => levels = value;
            }

            public void GenerateGuid()
            {
                guid = System.Guid.NewGuid().ToString();
            }
        }
    }
}