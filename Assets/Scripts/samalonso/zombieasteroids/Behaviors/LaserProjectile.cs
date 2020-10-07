using UnityEngine;
using UnityEngine.UI;

namespace samalonso.zombieasteroids.Behaviors
{
    public class LaserProjectile : MonoBehaviour
    {
        public float laserProjectileCooldown = 2.0f;
        public float laserProjectileForce = 50.0f;

        private float laserProjectileTimer;
        private Rigidbody2D laserRigidBody;
        private Image laserSprite;
    
        void Awake () 
        {
            laserRigidBody = GetComponent<Rigidbody2D>();
            laserSprite = GetComponent<Image>();
        }
    
        void Update () 
        {
            laserProjectileTimer += Time.deltaTime;
     
            if(laserProjectileTimer < laserProjectileCooldown)
            {
                if (laserProjectileTimer > Constants.LaserUtils.TIME_TO_APPEAR_LASER)
                {
                    laserSprite.enabled = true;
                }
            
                laserRigidBody.AddForce(transform.up * laserProjectileForce);
            }
            else
            {
                Destroy(gameObject);
            }
        }
    }
}
