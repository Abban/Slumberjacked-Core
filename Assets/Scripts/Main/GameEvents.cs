using BBX.Library.EventManagement;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    public class ChangeSceneEvent : IEvent
    {
        public SceneReference Scene { get; }

        public ChangeSceneEvent(SceneReference scene)
        {
            Scene = scene;
        }
    }
    
    public class SceneChangedEvent : IEvent
    {
        public SceneReference Scene { get; }

        public SceneChangedEvent(SceneReference scene)
        {
            Scene = scene;
        }
    }
}