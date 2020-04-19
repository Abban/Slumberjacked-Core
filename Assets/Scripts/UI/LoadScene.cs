using UnityEngine;
using BBX.Main.SceneManagement;
using BBX.Main.GameManagement;
using BBX.Utility;

namespace UI
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