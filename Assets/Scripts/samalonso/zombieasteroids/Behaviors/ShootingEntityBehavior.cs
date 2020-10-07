using UnityEngine;

namespace samalonso.zombieasteroids.Behaviors
{
    public class ShootingEntityBehavior : MonoBehaviour
    {
        public GameObject laserProjectilePrefab;
        
        public void ShootProjectile()
        { 
            Instantiate(laserProjectilePrefab, transform.position, transform.rotation, transform.parent);
        }
    }
}


