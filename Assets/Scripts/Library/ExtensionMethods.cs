using UnityEngine;

namespace BBX.Library
{
    public static class ExtensionMethods
    {
        public static Vector2Int ToInt2(this Vector2 position)
        {
            return new Vector2Int((int) position.x, (int) position.y);
        }

        public static Vector2Int ToInt2(this Vector3 position)
        {
            return new Vector2Int((int) position.x, (int) position.y);
        }
    }
}