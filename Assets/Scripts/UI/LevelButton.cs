using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BBX.Main.Game;
using BBX.Main.Save.Models;
using BBX.Utility;

namespace BBX.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private EventBus eventBus = null;
        [SerializeField] private Level level = null;
        [SerializeField] private Button button = null;
        [SerializeField] private TextMeshProUGUI buttonText = null;

        
        private void Awake()
        {
            button.interactable = !level.Locked;
            buttonText.text = level.Name;
        }


        public void OnClick()
        {
            eventBus.Fire(new ChangeSceneEvent(level));
        }
    }
}