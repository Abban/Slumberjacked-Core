using System.Collections.Generic;
using System.Linq;
using BBX.Main.Game.Structure;
using UnityEngine;
using BBX.Main.Save.Models;
using BBX.Utility;

namespace BBX.Main.Game
{
    [CreateAssetMenu(fileName = "GameStructureRegistry", menuName = "BBX/Game/Registry")]
    public class GameStructureRegistry : ScriptableObject
    {
        [SerializeField] private EventBus gameEventBus = null;
        [SerializeField] private List<LevelReference> levels = new List<LevelReference>();
        [SerializeField] private List<WorldReference> worlds = new List<WorldReference>();

        public List<WorldReference> Worlds => worlds;
        public List<LevelReference> Levels => levels;


        public void Initialise()
        {
            gameEventBus.Subscribe<SaveLoadedEvent>(OnLoadGameData);
        }


        private void OnDisable()
        {
            if (Application.isPlaying)
            {
                gameEventBus.Unsubscribe<SaveLoadedEvent>(OnLoadGameData);
            }
        }


        public List<LevelModel> GetLevels()
        {
            return levels.Select(level => new LevelModel(
                level.Guid,
                level.Locked
            )).ToList();
        }


        public List<WorldModel> GetWorlds()
        {
            return worlds.Select(world => new WorldModel(
                world.Guid,
                world.Locked
            )).ToList();
        }


        public LevelReference GetLevel(string guid)
        {
            return levels.FirstOrDefault(level => level.Guid == guid);
        }


        public WorldReference GetWorld(string guid)
        {
            return worlds.FirstOrDefault(world => world.Guid == guid);
        }


        public void OnLoadGameData(SaveLoadedEvent saveLoadedEvent)
        {
            foreach (var world in saveLoadedEvent.GameModelData.Worlds)
            {
                var worldReference = GetWorld(world.Guid);
                if (worldReference == null)
                {
                    // TODO: Add exception handler
                    continue;
                }

                worldReference.SetLocked(world.Locked);
            }

            foreach (var level in saveLoadedEvent.GameModelData.Levels)
            {
                var levelReference = GetLevel(level.Guid);
                if (levelReference == null)
                {
                    // TODO: Add exception handler
                    continue;
                }

                levelReference.SetLocked(level.Locked);
            }
        }
    }
}