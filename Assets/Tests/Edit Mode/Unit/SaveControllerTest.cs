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
            _saveController = Resources.Load<SaveController>("TestSave/TestSaveController");
            
            _saveController.Initialise(
                new MockEventBus(),
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
            Assert.NotNull(_testDataRepository.FileName);
            Assert.NotNull(_testDataRepository.Data);
            Assert.That(_saveGame.FileName == _testDataRepository.FileName);
        }


        [Test]
        public void OnInitialise_IfSaveDoesNotExist_ImportsDefaultStructure()
        {
            Assert.AreEqual(JsonUtility.ToJson(_saveGame.Save), _testDataRepository.Data);
        }


        [Test]
        public void OnSave_OverwritesSave()
        {
            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);
            
            _saveGame.ContentPacks[0].Save.Locked = true;
            _saveController.Save();
            
            Assert.That(_saveGame.ContentPacks[0].Save.Locked);
        }


        [Test]
        public void OnLoad_LoadsSave()
        {
            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);

            _saveGame.ContentPacks[0].Save.Locked = true;
            _saveController.Load();
            
            Assert.That(!_saveGame.ContentPacks[0].Save.Locked);
        }


        [Test]
        public void OnDelete_DeletesSave()
        {
            Assert.NotNull(_testDataRepository.FileName);
            Assert.NotNull(_testDataRepository.Data);
            
            _saveController.Delete();
            
            Assert.Null(_testDataRepository.FileName);
            Assert.Null(_testDataRepository.Data);
        }
    }
}