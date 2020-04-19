using System;
using UnityEngine;
using BBX.Main.SaveManagement.Interfaces;
using BBX.Main.SaveManagement.Models;

namespace BBX.Main.SaveManagement
{
    public class SaveDataRepository : IDataRepository<Game>
    {
        /// <inheritdoc />
        public void Save(Game data, string filename)
        {
            System.IO.File.WriteAllText(
                filename,
                JsonUtility.ToJson(data, true)
            );
        }

        
        /// <inheritdoc />
        public void Load(Game data, string filename)
        {
            if (!Exists(filename))
            {
                const string exception = "Tried to load save file that did not exist";
#if UNITY_EDITOR
                throw new Exception(exception);
#else
                Debug.LogException(new Exception(exception));
#endif
            }

            JsonUtility.FromJsonOverwrite(
                System.IO.File.ReadAllText(filename),
                data
            );
        }

        
        /// <inheritdoc />
        public bool Exists(string filename)
        {
            return System.IO.File.Exists(filename);
        }

        
        /// <inheritdoc />
        public void Delete(string filename)
        {
            System.IO.File.Delete(filename);
        }
    }
}