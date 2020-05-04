using BBX.Library.EventManagement;
using BBX.Main.Game;
using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;

namespace BBX.Main.Save
{
    public class SaveController
    {
        private SaveGame _saveGame;
        private readonly IEventBus _eventBus;
        private readonly IDataRepository<SaveGame.SaveData> _dataRepository;

        public SaveController(
            SaveGame saveGame,
            IEventBus eventBus,
            IDataRepository<SaveGame.SaveData> dataRepository)
        {
            _saveGame = saveGame;
            _eventBus = eventBus;
            _dataRepository = dataRepository;
        }


        public void Initialise()
        {
#if UNITY_EDITOR
            Delete();
#endif
            
            if (!_dataRepository.Exists(_saveGame.FileName))
            {
                Save();
            }

            Load();
        }


        public void Save()
        {
            _dataRepository.Save(_saveGame.Save, _saveGame.FileName);
        }


        public void Load()
        {
            _saveGame.Save = _dataRepository.Load(_saveGame.FileName);
            _eventBus.Fire(new SaveLoadedEvent(_saveGame));
        }


        public void Delete()
        {
            _dataRepository.Delete(_saveGame.FileName);
        }
    }
}