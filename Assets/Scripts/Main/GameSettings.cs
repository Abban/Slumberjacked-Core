using System;
using UnityEngine;
using BBX.Main.SceneManagement;

namespace BBX.Main
{
    [CreateAssetMenu(fileName = "GameSettings", menuName = "BBX/Game Settings")]
    public class GameSettings : ScriptableObject
    {
        [SerializeField] private ScenesReferences scenes = null;

        public ScenesReferences Scenes => scenes;

        [Serializable]
        public class ScenesReferences
        {
            [SerializeField] private SceneReference defaultScene = null;
            [SerializeField] private SceneReference mainMenu = null;
            [SerializeField] private SceneReference level = null;

            public SceneReference DefaultScene => defaultScene;
            public SceneReference MainMenu => mainMenu;
            public SceneReference Level => level;
        }
    }
}