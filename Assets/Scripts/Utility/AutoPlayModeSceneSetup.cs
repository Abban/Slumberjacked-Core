using System.Linq;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using BBX.Main.Game;

namespace BBX.Utility
{
    [InitializeOnLoad]
    public class AutoPlayModeSceneSetup
    {
        static AutoPlayModeSceneSetup()
        {
            if (EditorBuildSettings.scenes.Length == 0) return;
            
            var rootObjects = UnityEngine.SceneManagement.SceneManager.GetActiveScene().GetRootGameObjects();

            var sceneReferenceToLoad = rootObjects.FirstOrDefault(x => x.name == "SceneReferenceToLoad")
                ?.GetComponent<SceneReferenceToLoad>();

            if (sceneReferenceToLoad == null) return;
            
            var gameSettings = Resources.Load<GameSettings>("Settings/Game/GameSettings");
            
            gameSettings.Scenes.SetDefaultSceneOverride(sceneReferenceToLoad.SceneReference);

            EditorSceneManager.playModeStartScene = AssetDatabase.LoadAssetAtPath<SceneAsset>(EditorBuildSettings.scenes[0].path);

        }
    }
}