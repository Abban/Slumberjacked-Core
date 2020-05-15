using System;
using UnityEditor;
using UnityEngine;
using BBX.Main.Scene.Interfaces;

namespace BBX.Main.Save.Models
{
    [CreateAssetMenu(fileName = "Level", menuName = "BBX/Content/Level")]
    public class Level : ScriptableObject, ISceneReference
    {
        [SerializeField] private SaveData saveData = null;
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private string levelName = string.Empty;
        [SerializeField] private SceneAsset scene = null;
        
        [Header("Unlocks")]
        [SerializeField] private Level levelToUnlock = null;
        [SerializeField] private World worldToUnlock = null;
        
        public SaveData Save
        {
            get => saveData;
            set => saveData = value;
        }
        
        public SceneAsset Scene => scene;
        public string SceneName => scene.name;
        public string Guid => guid;
        public string Name => levelName;

        public bool Locked
        {
            get => Save.Locked;
            set => Save.Locked = value;
        }
        public Level LevelToUnlock => levelToUnlock;
        public World WorldToUnlock => worldToUnlock;
        
        public void GenerateGuid()
        {
            Save.GenerateGuid();
            guid = Save.Guid;
        }


        [Serializable]
        public class SaveData
        {
            [SerializeField] private bool locked = true;
            [SerializeField] private string guid = string.Empty;

            public bool Locked
            {
                get => locked;
                set => locked = value;
            }
            
            public string Guid => guid;

            public void GenerateGuid()
            {
                guid = System.Guid.NewGuid().ToString();
            }
        }
    }
}