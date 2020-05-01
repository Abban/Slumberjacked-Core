using UnityEngine;
using BBX.Main.Scene;

namespace BBX.Main.Game.Structure
{
    [CreateAssetMenu(fileName = "LevelReference", menuName = "BBX/Structure/Level Reference")]
    public class LevelReference : SceneReference
    {
        [SerializeField] private string guid = string.Empty;
        [SerializeField] private bool locked = true;
        
        public string Guid {
            get
            {
                if (guid == string.Empty)
                {
                    guid = System.Guid.NewGuid().ToString();
                }

                return guid;
            }
        }

        public bool Locked => locked;

        public void SetLocked(bool toLocked)
        {
            locked = toLocked;
        }

        public void Unlock()
        {
            SetLocked(false);
        }
    }
}