using System;
using UnityEngine;
using BBX.Main.Scene;

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

            public SceneReference DefaultScene => defaultScene;
            public SceneReference MainMenu => mainMenu;
            public SceneReference Shop => shop;
        }
    }
}