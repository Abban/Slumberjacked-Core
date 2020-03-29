using System.Collections;

namespace BBX.Main.SceneManagement
{
    public interface ISceneTransition
    {
        IEnumerator Show();
        IEnumerator Hide();
    }
}