using UnityEngine;

namespace samalonso.zombieasteroids.Utils
{
    public class Helpers : MonoBehaviour
    {
        public static float AngleBetweenVector2(Vector2 vec1, Vector2 vec2)
        {
            var vDirection = vec2 - vec1;
            var angle = Mathf.Atan2(vDirection.y,  vDirection.x) * Mathf.Rad2Deg;
            if (angle < 0f) angle += 360f;
            return angle;
        }
        
        public static float RandomNumbersInterval(float min, float max)
        {
            return Random.Range(min, max);
        }
        
        public static Vector2 GetRandomVectorInterval(float min, float max)
        {
            return new Vector2(RandomNumbersInterval(-min, min), RandomNumbersInterval(-max, max));
        }
    }
}
