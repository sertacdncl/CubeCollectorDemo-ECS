using UnityEngine;

namespace Game
{
    public static class QuaternionExtension
    {
        public static Quaternion GetEulerQuaternion(this Vector2Int vector2Int)
        {
            return Quaternion.Euler(vector2Int.x, vector2Int.y, 0);
        }
    }
}
