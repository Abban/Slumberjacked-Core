using BBX.Library.StateObserver;
using UnityEngine;

namespace BBX.Main.Level
{
    [CreateAssetMenu(fileName = "LevelState", menuName = "BBX/Level/State")]
    public class LevelState : ScriptableObject
    {
        public enum GameplayStates
        {
            Starting,
            Playing,
            Paused,
            Finishing,
            Resetting
        }
        
        public IObservableStateProperty<GameplayStates> GameplayState { get; set; }

        public void Initialise(
            IStatePropertyBroker stateBroker)
        {
            GameplayState = new ObservableStateProperty<GameplayStates>(stateBroker, GameplayStates.Starting);
        }
    }
}