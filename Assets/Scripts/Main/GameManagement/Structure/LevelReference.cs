using UnityEngine;
using UnityEditor;
using BBX.Main.SaveManagement.Models;

namespace BBX.Main.LevelSelectManagement
{
    [CreateAssetMenu(fileName = "LevelReference", menuName = "BBX/Level Select/Level Reference")]
    public class LevelReference : ScriptableObject
    {
        [SerializeField] private SceneAsset scene = null;
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private bool locked = true;
        
        public string Guid => guid;
        public bool Locked => locked;

        public void SetLocked(bool toLocked)
        {
            locked = toLocked;
        }

        public SceneAsset Scene => scene;
        public string SceneName => scene.name;


        public void Unlock()
        {
            SetLocked(false);
        }


        public Level ToLevel()
        {
            if (guid == string.Empty)
            {
                guid = System.Guid.NewGuid().ToString();
            }
            
            return new Level(guid, locked);
        }
        
        
        public void FromLevel(Level level)
        {
            guid = level.Guid;
            locked = level.Locked;
        }
    }
}