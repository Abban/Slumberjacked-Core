using System.Collections;
using BBX.Main.Scene;

namespace BBX.TestMocks
{
    public class MockSceneTransition : ISceneTransition
    {
        public bool IsVisible { get; } = false;

        public IEnumerator Show()
        {
            yield return null;
        }

        public IEnumerator Hide()
        {
            yield return null;
        }
    }
}