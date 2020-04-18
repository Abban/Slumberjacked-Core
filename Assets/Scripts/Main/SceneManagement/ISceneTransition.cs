using System.Collections;

namespace BBX.Main.SceneManagement
{
    public interface ISceneTransition
    {
        bool IsVisible { get; }
        IEnumerator Show();
        IEnumerator Hide();
    }
}