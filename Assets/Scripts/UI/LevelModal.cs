using BBX.Main.Level;
using BBX.Utility;
using UnityEngine;

namespace BBX.UI
{
    public class LevelModal : Modal
    {
        [SerializeField] private LevelState.GameplayStates visibleInState = LevelState.GameplayStates.Starting;
        [SerializeField] private LevelState levelState = null;
        [SerializeField] private EventBus gameEventBus = null;
        
        
        private void Awake()
        {
            gameEventBus.Subscribe<LevelInitialisedEvent>(OnLevelInitialised);
        }


        private void OnLevelInitialised(LevelInitialisedEvent levelInitialisedEvent)
        {
            levelState.GameplayState.Action += OnLevelStateChange;
        }


        private void OnDisable()
        {
            levelState.GameplayState.Action -= OnLevelStateChange;
            gameEventBus.Unsubscribe<LevelInitialisedEvent>(OnLevelInitialised);
        }

        
        private void OnLevelStateChange()
        {
            if (levelState.GameplayState.Value == visibleInState)
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