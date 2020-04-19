using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using BBX.Main.GameManagement.Structure;
using BBX.Main.SaveManagement.Models;
using BBX.Utility;

namespace BBX.Main.GameManagement
{
    [CreateAssetMenu(fileName = "LevelRegistry", menuName = "BBX/Level Select/Registry")]
    public class LevelRegistry : ScriptableObject
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


        public List<Level> GetLevels()
        {
            return levels.Select(level => level.ToLevel()).ToList();
        }


        // private static Level LevelFromReference(LevelReference levelReference)
        // {
        //     return new Level(
        //         levelReference.Guid,
        //         levelReference.Locked
        //     );
        // }


        public List<World> GetWorlds()
        {
            return worlds.Select(world => world.ToWorld()).ToList();
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
            foreach (var world in saveLoadedEvent.GameData.Worlds)
            {
                var worldReference = GetWorld(world.Guid);
                if (worldReference == null)
                {
                    // TODO: Add exception handler
                    continue;
                }

                worldReference.FromWorld(world);
            }

            foreach (var level in saveLoadedEvent.GameData.Levels)
            {
                var levelReference = GetLevel(level.Guid);
                if (levelReference == null)
                {
                    // TODO: Add exception handler
                    continue;
                }

                levelReference.FromLevel(level);
            }
        }
    }
}