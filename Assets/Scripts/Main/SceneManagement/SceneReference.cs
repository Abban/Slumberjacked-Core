using UnityEditor;
using UnityEngine;

namespace BBX.Main.SceneManagement
{
    [CreateAssetMenu(fileName = "SceneReference", menuName = "BBX/Scene Reference")]
    public class SceneReference : ScriptableObject
    {
        [SerializeField] private SceneAsset scene = null;
        public SceneAsset Scene => scene;
        public string SceneName => scene.name;
    }
}