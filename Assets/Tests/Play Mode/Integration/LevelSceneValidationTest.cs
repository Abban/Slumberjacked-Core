using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using BBX.Main.Game;
using BBX.Main.Level;

namespace Play.Unit.Game
{
    [TestFixture]
    public class LevelSceneValidationTest
    {
        [TearDown]
        public void TearDown()
        {
            SceneManager.LoadScene("Test Scene");
        }
        
        
        [UnityTest]
        public IEnumerator AllLevelScenesAreSetupCorrectly()
        {
            var gameStructureRegistry = Resources.Load<GameStructureRegistry>("Settings/Game/GameStructureRegistry");
            
            foreach (var level in gameStructureRegistry.Levels)
            {
                yield return SceneManager.LoadSceneAsync(level.SceneName, LoadSceneMode.Single);
                
                Assert.NotNull(
                    Object.FindObjectOfType(typeof(LevelFacade)),
                    $"{level.SceneName} is missing LevelFacade"
                );
                
                Assert.NotNull(
                    GameObject.Find("PlayerSpawnPoint"),
                    $"{level.SceneName} is missing PlayerSpawnPoint"
                );
            }
        }
    }
}