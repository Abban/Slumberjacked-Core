using System;
using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;
using BBX.Utility;
using UnityEngine;

namespace BBX.Main.Save
{
    public class SaveDataRepository : IDataRepository<SaveGame.SaveData>
    {
        /// <inheritdoc />
        public void Save(SaveGame.SaveData data, string fileName)
        {
            System.IO.File.WriteAllText(
                fileName,
                JsonUtility.ToJson(data, true)
            );
        }

        
        /// <inheritdoc />
        public SaveGame.SaveData Load(string fileName)
        {
            if (!Exists(fileName))
            {
                ExceptionLogger.Exception("Tried to load save file that did not exist");
            }

            return JsonUtility.FromJson<SaveGame.SaveData>(System.IO.File.ReadAllText(fileName));
        }

        
        /// <inheritdoc />
        public bool Exists(string fileName)
        {
            return System.IO.File.Exists(fileName);
        }

        
        /// <inheritdoc />
        public void Delete(string fileName)
        {
            System.IO.File.Delete(fileName);
        }
    }
}