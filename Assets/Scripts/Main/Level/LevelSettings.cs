using System;
using BBX.Actor;
using BBX.Actor.Input;
using BBX.Actor.Interfaces;
using UnityEngine;

namespace BBX.Main.Level
{
    [Serializable]
    public class LevelSettings
    {
        [SerializeField] private ActorFacade playerPrefab = null;
        [SerializeField] private Transform playerSpawnPoint = null;
        [SerializeField] private PlayerInputBrain playerInputBrain = null;
        
        
        public ActorFacade PlayerPrefab => playerPrefab;
        public Transform PlayerSpawnPoint => playerSpawnPoint;
        public IActorBrain PlayerInputBrain => playerInputBrain;
    }
}