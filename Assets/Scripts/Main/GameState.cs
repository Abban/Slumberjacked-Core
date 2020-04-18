using UnityEngine;
using BBX.Library.StateObserver;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    [CreateAssetMenu(fileName = "GameState", menuName = "BBX/Game/State")]
    public class GameState : ScriptableObject
    {
        public IObservableStateProperty<SceneReference> CurrentScene { get; set; }

        public void Initialise(
            IStatePropertyBroker stateBroker,
            SceneReference defaultScene)
        {
            CurrentScene = new ObservableStateProperty<SceneReference>(stateBroker, defaultScene);
        }
    }
}