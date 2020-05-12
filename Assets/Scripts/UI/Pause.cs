using UnityEngine;
using BBX.Utility;
using BBX.Main.Level;

namespace BBX.UI
{
    public class Pause : Modal
    {
        [SerializeField] private LevelState levelState = null;
        [SerializeField] private EventBus gameEventBus = null;
        
        private LevelState.GameplayStates _lastState;
        
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
            if (levelState.GameplayState.Value == LevelState.GameplayStates.Paused)
            {
                Show();
            }
            else if (_lastState == LevelState.GameplayStates.Paused)
            {
                Hide();
            }

            _lastState = levelState.GameplayState.Value;
        }
    }
}