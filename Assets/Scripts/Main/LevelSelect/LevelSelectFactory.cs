using UnityEngine;

namespace BBX.Main.LevelSelect
{
    [CreateAssetMenu(fileName = "LevelSelectFactory", menuName = "BBX/Level Select/Factory")]
    public class LevelSelectFactory : ScriptableObject
    {
        private LevelSelectController _levelSelectController;

        public LevelSelectController LevelSelectController
        {
            get
            {
                if (_levelSelectController == null)
                {
                    _levelSelectController = new LevelSelectController();
                }

                return _levelSelectController;
            }
        }
    }
}