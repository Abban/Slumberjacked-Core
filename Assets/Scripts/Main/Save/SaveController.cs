using System;
using System.Collections.Generic;
using BBX.Main.Game;
using BBX.Main.Save.Interfaces;
using BBX.Main.Save.Models;
using BBX.Utility;
using UnityEngine;

namespace BBX.Main.Save
{
    public class SaveController
    {
        private GameModel _gameModelData;
        private readonly GameModel _defaultGameModelData;
        private readonly EventBus _eventBus;
        private readonly IDataRepository<GameModel> _dataRepository;
        private readonly List<WorldModel> _worlds;
        private readonly List<LevelModel> _levels;
        
        private const string FileName = "save.bbx";

        public SaveController(
            Components components,
            EventBus eventBus,
            IDataRepository<GameModel> dataRepository,
            List<WorldModel> worlds,
            List<LevelModel> levels)
        {
            _gameModelData = components.GameModelData;
            _defaultGameModelData = components.DefaultGameModelData;
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
                _gameModelData = _defaultGameModelData;
                _gameModelData.SetReferences(_worlds, _levels);
                
                Save();
            }
            
            Load();
        }


        public void Save()
        {
            _dataRepository.Save(_gameModelData, FileName);
        }


        public void Load()
        {
            _dataRepository.Load(_gameModelData, FileName);
            _eventBus.Fire(new SaveLoadedEvent(_gameModelData));
        }
        
        
        public void Delete()
        {
            _dataRepository.Delete(FileName);
        }
        
        
        [Serializable]
        public class Components
        {
            [SerializeField] private GameModel gameModelData = null;
            [SerializeField] private GameModel defaultGameModelData = null;

            public GameModel GameModelData => gameModelData;
            public GameModel DefaultGameModelData => defaultGameModelData;
        }
    }
}