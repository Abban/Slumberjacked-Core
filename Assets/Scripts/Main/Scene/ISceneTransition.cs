using System.Collections;

namespace BBX.Main.Scene
{
    public interface ISceneTransition
    {
        bool IsVisible { get; }
        IEnumerator Show();
        IEnumerator Hide();
    }
}