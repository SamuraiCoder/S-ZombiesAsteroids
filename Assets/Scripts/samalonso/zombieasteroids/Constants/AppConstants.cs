namespace samalonso.zombieasteroids.Constants
{
    public enum ReasonTypeCollision
    {
        CollisionWithPlayer,
        CollisionWithAsteroid,
        CollisionWithLaser
    }
    
    public class LevelContants
    {
        public static string ENEMY_PREFIX_NAME = "Phantom_";
    }

    public class EnemyAI
    {
        public static float CHECK_FOR_CHASE_AI_EXPIRATION_TIME = 1.0f;
        public static string PLAYER_SHIP_NAME = "Eagle_1";
        public static float MIN_SPEED_ENEMY = 50;
        public static float MAX_SPEED_ENEMY = 500;
    }

    public class LaserUtils
    {
        public static float TIME_TO_APPEAR_LASER = 0.200f;
    }
}
