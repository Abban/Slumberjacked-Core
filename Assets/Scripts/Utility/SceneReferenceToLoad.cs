using UnityEngine;
using BBX.Main.Scene.Interfaces;

namespace BBX.Utility
{
    public class SceneReferenceToLoad : MonoBehaviour
    {
        [SerializeField] private Object sceneReference = null;
        
        public ISceneReference SceneReference => sceneReference as ISceneReference;
    }
}