using NUnit.Framework;
using UnityEngine;
using BBX.TestMocks;
using BBX.Main.Save;
using BBX.Main.Save.Models;

namespace Unit.Game
{
    [TestFixture]
    public class SaveControllerTest
    {
        private MockDataRepository _testDataRepository;
        private SaveGame _saveGame;
        private SaveController _saveController;

        [SetUp]
        public void SetUp()
        {
            _testDataRepository = new MockDataRepository();
            _saveGame = Resources.Load<SaveGame>("TestSave/TestSaveGame");

            var gameEventBus = new MockEventBus();

            _saveController = new SaveController(
                _saveGame,
                gameEventBus,
                _testDataRepository
            );
        }

        [TearDown]
        public void TearDown()
        {
            _saveGame.ContentPacks[0].Save.Locked = false;
        }


        [Test]
        public void OnInitialise_IfSaveDoesNotExist_CreatesDefaultSave()
        {
            _saveController.Initialise();
            
            Assert.NotNull(_testDataRepository.FileName);
            Assert.NotNull(_testDataRepository.Data);
            Assert.That(_saveGame.FileName == _testDataRepository.FileName);
        }


        [Test]
        public void OnInitialise_IfSaveDoesNotExist_ImportsDefaultStructure()
        {
            _saveController.Initialise();
            
            Assert.AreEqual(JsonUtility.ToJson(_saveGame.Save), _testDataRepository.Data);
        }


        [Test]
        public void OnSave_OverwritesSave()
        {
            _saveController.Initialise();
            
            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);
            
            _saveGame.ContentPacks[0].Save.Locked = true;
            _saveController.Save();
            
            Assert.That(_saveGame.ContentPacks[0].Save.Locked);
        }


        [Test]
        public void OnLoad_LoadsSave()
        {
            _saveController.Initialise();

            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);

            _saveGame.ContentPacks[0].Save.Locked = true;
            _saveController.Load();
            
            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);
        }


        [Test]
        public void OnDelete_DeletesSave()
        {
            _saveController.Initialise();
            
            Assert.NotNull(_testDataRepository.FileName);
            Assert.NotNull(_testDataRepository.Data);
            
            _saveController.Delete();
            
            Assert.Null(_testDataRepository.FileName);
            Assert.Null(_testDataRepository.Data);
        }
    }
}