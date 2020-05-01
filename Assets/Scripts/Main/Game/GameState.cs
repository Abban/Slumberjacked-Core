using UnityEngine;
using BBX.Library.StateObserver;
using BBX.Main.Scene;

namespace BBX.Main.Game
{
    [CreateAssetMenu(fileName = "GameState", menuName = "BBX/Game/State")]
    public class GameState : ScriptableObject
    {
        public enum LoadingStates
        {
            Idle,
            Loading
        }

        public IObservableStateProperty<SceneReference> CurrentScene { get; set; }
        public IObservableStateProperty<LoadingStates> LoadingState { get; set; }

        public void Initialise(
            IStatePropertyBroker stateBroker)
        {
            CurrentScene = new ObservableStateProperty<SceneReference>(stateBroker, null);
            LoadingState = new ObservableStateProperty<LoadingStates>(stateBroker, LoadingStates.Idle);
        }
    }
}