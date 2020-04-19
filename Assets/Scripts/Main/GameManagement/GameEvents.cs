using BBX.Library.EventManagement;
using BBX.Main.SaveManagement.Models;
using BBX.Main.SceneManagement;

namespace BBX.Main.GameManagement
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
    
    public class SaveLoadedEvent : IEvent
    {
        public Game GameData { get; }

        public SaveLoadedEvent(Game gameData)
        {
            GameData = gameData;
        }
    }
}