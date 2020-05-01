using System;
using BBX.Main.Save.Interfaces;
using UnityEngine;

namespace BBX.Main.Save
{
    public class SaveDataRepository : IDataRepository<Models.GameModel>
    {
        /// <inheritdoc />
        public void Save(Models.GameModel data, string filename)
        {
            System.IO.File.WriteAllText(
                filename,
                JsonUtility.ToJson(data, true)
            );
        }

        
        /// <inheritdoc />
        public void Load(Models.GameModel data, string filename)
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