using UnityEngine;
using BBX.Actor.Interfaces;
using BBX.Utility;

namespace BBX.Main.Level
{
    [CreateAssetMenu(fileName = "LevelFactory", menuName = "BBX/Level/Factory")]
    public class LevelFactory : ScriptableObject
    {
        [SerializeField] private LevelState levelState = null;
        [SerializeField] private StateBroker levelStateBroker = null;
        [SerializeField] private Board board = null;

        private LevelSettings _settings;

        public void Initialise(LevelSettings settings)
        {
            _settings = settings;

            levelState.Initialise(levelStateBroker);
            levelStateBroker.Initialise();
        }


        private LevelController _levelController;

        public LevelController LevelController
        {
            get
            {
                if (_levelController == null)
                {
                    _levelController = new LevelController(
                        levelState,
                        levelStateBroker,
                        board
                    );
                }

                return _levelController;
            }
        }


        private IActor _player;

        public IActor Player
        {
            get
            {
                if (_player == null)
                {
                    var player = Instantiate(_settings.PlayerPrefab, _settings.PlayerSpawnPoint);
                    _player = player.GetComponent<IActor>();
                }

                return _player;
            }
        }
    }
}