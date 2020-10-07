using pEventBus;
using samalonso.zombieasteroids.Behaviors;
using samalonso.zombieasteroids.Events;
using UnityEngine;

namespace samalonso.zombieasteroids.Ship
{
    public class PlayerShipController : Entity, IEventReceiver<PlayerShipMoveEvent>, IEventReceiver<PlayerShootLaserEvent>
    {
        [SerializeField]
        private float playerSpeed;

        private Vector2 playerDirection;
        private ShootingEntityBehavior shootingEntityBehavior;

        private void Start()
        {
            EventBus.Register(this);
            shootingEntityBehavior = GetComponent<ShootingEntityBehavior>();
        }

        private void OnDestroy()
        {
            EventBus.UnRegister(this);
        }

        protected override void Update()
        {
            direction = playerDirection;
            speed = playerSpeed;
            
            base.Update();
        }

        public void OnEvent(PlayerShipMoveEvent e)
        {
            playerDirection = e.Direction;
        }

        public void OnEvent(PlayerShootLaserEvent e)
        {
            shootingEntityBehavior.ShootProjectile();
        }
    }
}
