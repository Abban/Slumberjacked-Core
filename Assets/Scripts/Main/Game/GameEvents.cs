using BBX.Library.EventManagement;
using BBX.Main.Save.Models;
using BBX.Main.Scene.Interfaces;

namespace BBX.Main.Game
{
    public class ChangeSceneEvent : IEvent
    {
        public ISceneReference Scene { get; }

        public ChangeSceneEvent(ISceneReference scene)
        {
            Scene = scene;
        }
    }

    
    public class SceneChangedEvent : IEvent
    {
        public ISceneReference Scene { get; }

        public SceneChangedEvent(ISceneReference scene)
        {
            Scene = scene;
        }
    }


    public class SaveLoadedEvent : IEvent
    {
        public SaveGame SaveGame { get; }

        public SaveLoadedEvent(SaveGame saveGame)
        {
            SaveGame = saveGame;
        }
    }
}