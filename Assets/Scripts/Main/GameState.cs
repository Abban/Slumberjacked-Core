using BBX.Library.StateObserver;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    public class GameState
    {
        public IObservableStateProperty<SceneReference> CurrentScene { get; }
        
        
        public GameState(IObservableStateProperty<SceneReference> currentScene)
        {
            CurrentScene = currentScene;
        }
    }
}