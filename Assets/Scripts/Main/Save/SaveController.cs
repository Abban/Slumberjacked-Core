using BBX.Library.EventManagement;
using UnityEngine;
using BBX.Main.Game;
using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;

namespace BBX.Main.Save
{
    [CreateAssetMenu(fileName = "SaveController", menuName = "BBX/Game/Save Controller")]
    public class SaveController : ScriptableObject
    {
        [SerializeField] private SaveGame saveGame = null;
        
        private IEventBus _eventBus;
        private IDataRepository<SaveGame.SaveData> _dataRepository;

        public void Initialise(
            IEventBus eventBus,
            IDataRepository<SaveGame.SaveData> dataRepository)
        {
            _eventBus = eventBus;
            _dataRepository = dataRepository;
            
#if UNITY_EDITOR
            Delete();
#endif
            
            if (!_dataRepository.Exists(saveGame.FileName))
            {
                Save();
            }

            Load();
        }


        public void Save()
        {
            _dataRepository.Save(saveGame.Save, saveGame.FileName);
        }


        public void Load()
        {
            saveGame.Save = _dataRepository.Load(saveGame.FileName);
            _eventBus.Fire(new SaveLoadedEvent(saveGame));
        }


        public void Delete()
        {
            _dataRepository.Delete(saveGame.FileName);
        }
    }
}