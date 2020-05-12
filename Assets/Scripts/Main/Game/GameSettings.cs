using System;
using UnityEngine;
using BBX.Main.Scene;
using BBX.Main.Scene.Interfaces;

namespace BBX.Main.Game
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "BBX/Game/Settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private ScenesReferences scenes = null;

        public ScenesReferences Scenes => scenes;

        [Serializable]
        public class ScenesReferences
        {
            [SerializeField] private SceneReference defaultScene = null;
            [SerializeField] private SceneReference mainMenu = null;
            [SerializeField] private SceneReference shop = null;

            private ISceneReference _defaultSceneOverride = null;
            public ISceneReference DefaultScene => _defaultSceneOverride ?? defaultScene;
            public ISceneReference MainMenu => mainMenu;
            public ISceneReference Shop => shop;
            
            public void SetDefaultSceneOverride(ISceneReference sceneReference)
            {
                _defaultSceneOverride = sceneReference;
            }
        }
    }
}