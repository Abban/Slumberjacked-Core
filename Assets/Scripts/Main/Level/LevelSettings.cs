using System;
using System.Collections.Generic;
using UnityEngine;
using BBX.Actor;
using BBX.Actor.Interfaces;
using BBX.Main.Level.Utilities;

namespace BBX.Main.Level
{
    [Serializable]
    public class LevelSettings
    {
        [Header("Level")]
        [SerializeField] private Save.Models.Level level = null;
        [SerializeField] private ActorList actors = null;
        
        [Header("Player")]
        [SerializeField] private ActorFacade playerPrefab = null;
        [SerializeField] private Transform playerSpawnPoint = null;
        
        public Save.Models.Level Level => level;
        public List<IActor> Actors => actors.Actors;
        public ActorFacade PlayerPrefab => playerPrefab;
        public Transform PlayerSpawnPoint => playerSpawnPoint;
    }
}