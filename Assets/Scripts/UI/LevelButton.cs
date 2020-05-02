using UnityEngine;
using UnityEngine.UI;
using TMPro;
using BBX.Main.Game;
using BBX.Main.Game.Structure;
using BBX.Utility;

namespace BBX.UI
{
    public class LevelButton : MonoBehaviour
    {
        [SerializeField] private EventBus eventBus = null;
        [SerializeField] private LevelReference levelReference = null;
        [SerializeField] private Button button = null;
        [SerializeField] private TextMeshProUGUI buttonText = null;

        
        private void Awake()
        {
            buttonText.text = levelReference.Name;
            
            if (levelReference.Locked)
            {
                button.enabled = false;
            }
        }


        public void OnClick()
        {
            eventBus.Fire(new ChangeSceneEvent(levelReference));
        }
    }
}