using System;
using System.Collections.Generic;
using BBX.Main.GameManagement;
using BBX.Main.SaveManagement.Interfaces;
using BBX.Main.SaveManagement.Models;
using BBX.Utility;
using UnityEngine;

namespace BBX.Main.SaveManagement
{
    public class SaveController
    {
        private Game _gameData;
        private readonly Game _defaultGameData;
        private readonly EventBus _eventBus;
        private readonly IDataRepository<Game> _dataRepository;
        private readonly List<World> _worlds;
        private readonly List<Level> _levels;
        
        private const string FileName = "save.bbx";

        public SaveController(
            Components components,
            EventBus eventBus,
            IDataRepository<Game> dataRepository,
            List<World> worlds,
            List<Level> levels)
        {
            _gameData = components.GameData;
            _defaultGameData = components.DefaultGameData;
            _eventBus = eventBus;
            _dataRepository = dataRepository;
            _worlds = worlds;
            _levels = levels;
        }


        public void Initialise()
        {
#if UNITY_EDITOR
            Delete();
#endif
            
            if (!_dataRepository.Exists(FileName))
            {
                _gameData = _defaultGameData;
                _gameData.SetLevelReferences(_worlds, _levels);
                
                Save();
            }
            
            Load();
        }


        public void Save()
        {
            _dataRepository.Save(_gameData, FileName);
        }


        public void Load()
        {
            _dataRepository.Load(_gameData, FileName);
            _eventBus.Fire(new SaveLoadedEvent(_gameData));
        }
        
        
        public void Delete()
        {
            _dataRepository.Delete(FileName);
        }
        
        [Serializable]
        public class Components
        {
            [SerializeField] private Game gameData = null;
            [SerializeField] private Game defaultGameData = null;

            public Game GameData => gameData;
            public Game DefaultGameData => defaultGameData;
        }
    }
}