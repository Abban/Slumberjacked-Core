using UnityEditor;

namespace BBX.Main.Scene.Interfaces
{
    public interface ISceneReference
    {
        SceneAsset Scene { get; }
        string SceneName { get; }
    }
}