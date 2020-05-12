using UnityEngine;
using BBX.Library.StateObserver;
using BBX.Main.Scene.Interfaces;

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

        public IObservableStateProperty<ISceneReference> CurrentScene { get; private set; }
        public IObservableStateProperty<LoadingStates> LoadingState { get; private set; }

        public void Initialise(
            IStatePropertyBroker stateBroker)
        {
            CurrentScene = new ObservableStateProperty<ISceneReference>(stateBroker, null);
            LoadingState = new ObservableStateProperty<LoadingStates>(stateBroker, LoadingStates.Idle);
        }
    }
}