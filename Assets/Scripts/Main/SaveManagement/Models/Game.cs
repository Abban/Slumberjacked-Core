using System;
using System.Collections.Generic;
using UnityEngine;

namespace BBX.Main.SaveManagement.Models
{
    [Serializable]
    [CreateAssetMenu(fileName = "Game", menuName = "BBX/Save/Game")]
    public class Game : ScriptableObject
    {
        [SerializeField] private List<World> worlds = null;
        [SerializeField] private List<Level> levels = null;
        [SerializeField] private World lastUnlockedWorld = new World();
        [SerializeField] private Level lastUnlockedLevel = new Level();
        
        public List<World> Worlds => worlds;
        public List<Level> Levels => levels;
        public World LastUnlockedWorld => lastUnlockedWorld;
        public Level LastUnlockedLevel => lastUnlockedLevel;


        public void SetLevelReferences(
            List<World> gameWorlds,
            List<Level> gameLevels)
        {
            worlds = gameWorlds;
            levels = gameLevels;
        }
    }
}