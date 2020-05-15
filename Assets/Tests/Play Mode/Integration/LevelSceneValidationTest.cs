using System.Collections;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;
using BBX.Main.Level;
using BBX.Main.Save.Models;
using BBX.Utility;

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
            var saveGame = Resources.Load<SaveGame>("Settings/Content/SaveGame");
            var eventBus = Resources.Load<EventBus>("Settings/Game/GameEventBus");
            eventBus.Initialise();

            var levels = saveGame.ContentPacks.SelectMany(pack => pack.Worlds)
                .SelectMany(world => world.Levels);
            
            foreach (var level in levels)
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