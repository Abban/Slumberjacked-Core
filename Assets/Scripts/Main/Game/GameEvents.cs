using BBX.Library.EventManagement;
using BBX.Main.Save.Models;
using BBX.Main.Scene;

namespace BBX.Main.Game
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
        public GameModel GameModelData { get; }

        public SaveLoadedEvent(GameModel gameModelData)
        {
            GameModelData = gameModelData;
        }
    }
}