using BBX.Main.Level;
using BBX.Utility;
using UnityEngine;

namespace BBX.UI
{
    public class ResetLevel : MonoBehaviour
    {
        [SerializeField] private EventBus eventBus = null;

        public void OnClick()
        {
            eventBus.Fire(new LevelResetEvent());
        }
    }
}