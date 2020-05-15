using UnityEngine;
using BBX.Main.Level;
using BBX.Utility;

namespace BBX.UI
{
    public class DieButton : MonoBehaviour
    {
        [SerializeField] private EventBus gameEventBus = null;
        
        public void OnClick()
        {
            gameEventBus.Fire(new LevelDieEvent());
        }
    }
}