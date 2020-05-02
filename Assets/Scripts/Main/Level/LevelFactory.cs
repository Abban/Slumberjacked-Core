using UnityEngine;

namespace BBX.Main.Level
{
    [CreateAssetMenu(fileName = "LevelFactory", menuName = "BBX/Level/Factory")]
    public class LevelFactory : ScriptableObject
    {
        private LevelController _levelController;

        public LevelController LevelController
        {
            get
            {
                if (_levelController == null)
                {
                    _levelController = new LevelController();
                }

                return _levelController;
            }
        }
    }
}