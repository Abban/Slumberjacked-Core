using System;
using System.Collections.Generic;
using UnityEngine;

namespace BBX.Main.Save.Models
{
    [Serializable]
    [CreateAssetMenu(fileName = "Game", menuName = "BBX/Save/Game")]
    public class GameModel : ScriptableObject
    {
        [SerializeField] private List<WorldModel> worlds = null;
        [SerializeField] private List<LevelModel> levels = null;
        [SerializeField] private WorldModel lastUnlockedWorldModel = new WorldModel();
        [SerializeField] private LevelModel lastUnlockedLevelModel = new LevelModel();
        
        public List<WorldModel> Worlds => worlds;
        public List<LevelModel> Levels => levels;
        public WorldModel LastUnlockedWorldModel => lastUnlockedWorldModel;
        public LevelModel LastUnlockedLevelModel => lastUnlockedLevelModel;


        public void SetReferences(
            List<WorldModel> gameWorlds,
            List<LevelModel> gameLevels)
        {
            worlds = gameWorlds;
            levels = gameLevels;
        }
    }
}