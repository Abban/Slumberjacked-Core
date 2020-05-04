using UnityEditor;
using UnityEngine;
using BBX.Main.Scene.Interfaces;

namespace BBX.Main.Scene
{
    [CreateAssetMenu(fileName = "SceneReference", menuName = "BBX/Scene/Reference")]
    public class SceneReference : ScriptableObject, ISceneReference
    {
        [SerializeField] private SceneAsset scene = null;
        public SceneAsset Scene => scene;
        public string SceneName => scene.name;
    }
}