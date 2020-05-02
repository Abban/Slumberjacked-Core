using UnityEngine;
using BBX.Main.Scene;
using BBX.Main.Game;
using BBX.Utility;

namespace BBX.UI
{
    public class LoadScene : MonoBehaviour
    {
        [SerializeField] private EventBus eventBus = null;

        public void OnClick(SceneReference scene)
        {
            eventBus.Fire(new ChangeSceneEvent(scene));
        }
    }
}