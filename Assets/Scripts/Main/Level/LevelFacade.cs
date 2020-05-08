using UnityEngine;

namespace BBX.Main.Level
{
    public class LevelFacade : MonoBehaviour
    {
        [SerializeField] private LevelFactory levelFactory = null;
        [SerializeField] private LevelSettings levelSettings = null;
        
        private LevelController _levelController;

        private void Awake()
        {
            levelFactory.Initialise(levelSettings);
            _levelController = levelFactory.LevelController;
            _levelController.Awake();
        }


        private void Start()
        {
            _levelController.Start();
            var player = levelFactory.Player;
        }
    }
}