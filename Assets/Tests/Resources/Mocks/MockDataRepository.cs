using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;
using UnityEngine;

namespace BBX.TestMocks
{
    public class MockDataRepository : IDataRepository<SaveGame.SaveData>
    {
        public string Data { get; set; }
        public string FileName { get; set; }


        public void Save(SaveGame.SaveData data, string fileName)
        {
            Data = JsonUtility.ToJson(data);
            FileName = fileName;
        }

        public SaveGame.SaveData Load(string fileName)
        {
            return JsonUtility.FromJson<SaveGame.SaveData>(Data);
        }

        public bool Exists(string fileName)
        {
            return Data != null;
        }

        public void Delete(string fileName)
        {
            Data = null;
            FileName = null;
        }
    }
}