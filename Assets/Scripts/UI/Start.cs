using BBX.Main.Level;
using BBX.Utility;
using UnityEngine;

namespace BBX.UI
{
    public class Start : Modal
    {
        [SerializeField] private LevelState levelState = null;
        [SerializeField] private EventBus gameEventBus = null;
        
        
        private void Awake()
        {
            gameEventBus.Subscribe<LevelStartEvent>(OnLevelStart);
        }


        private void OnLevelStart(LevelStartEvent levelStartEvent)
        {
            levelState.GameplayState.Action += OnLevelStateChange;
        }


        private void OnDisable()
        {
            levelState.GameplayState.Action -= OnLevelStateChange;
            gameEventBus.Unsubscribe<LevelStartEvent>(OnLevelStart);
        }


        private void OnLevelStateChange()
        {
            if (levelState.GameplayState.Value == LevelState.GameplayStates.Starting)
            {
                Show();
            }
            else
            {
                Hide();
            }
        }
    }
}