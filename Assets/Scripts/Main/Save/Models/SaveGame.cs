using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BBX.Main.Save.Models
{
    [CreateAssetMenu(fileName = "SaveGame", menuName = "BBX/Save/Save Game")]
    public class SaveGame : ScriptableObject
    {
        [SerializeField] private SaveData saveData = null;
        [SerializeField] private string saveName = string.Empty;
        [SerializeField] private List<ContentPack> contentPacks = null;
        
        public SaveData Save
        {
            get
            {
                saveData.ContentPacks = contentPacks.Select(world => world.Save).ToList();
                return saveData;
            }
            set
            {
                foreach (var contentPackData in value.ContentPacks)
                {
                    var contentPack = contentPacks.FirstOrDefault(w => w.Guid == contentPackData.Guid);
                    if (contentPack == null) continue;
                    contentPack.Save = contentPackData;
                }
                saveData = value;
            }
        }
        
        public string FileName => $"{saveName}.bbx";
        public List<ContentPack> ContentPacks => contentPacks;
        
        
        public void GenerateGuids()
        {
            foreach (var contentPack in contentPacks)
            {
                contentPack.GenerateGuids();
            }
        }


        [Serializable]
        public class SaveData
        {
            [SerializeField] private List<ContentPack.SaveData> contentPacks = null;

            public List<ContentPack.SaveData> ContentPacks
            {
                get => contentPacks;
                set => contentPacks = value;
            }
        }
    }
}