using System;
using UnityEngine;

namespace BBX.Main.Level
{
    public class LevelFacade : MonoBehaviour
    {
        [SerializeField] private LevelFactory levelFactory = null;
        private LevelController _levelController;

        private void Awake()
        {
            _levelController = levelFactory.LevelController;
        }


        private void Start()
        {
            _levelController.Start();
        }
    }
}