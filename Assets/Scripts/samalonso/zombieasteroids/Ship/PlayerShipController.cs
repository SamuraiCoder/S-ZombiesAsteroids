using pEventBus;
using samalonso.zombieasteroids.Behaviors;
using samalonso.zombieasteroids.Events;
using samalonso.zombieasteroids.Services;
using UnityEngine;
using Zenject;

namespace samalonso.zombieasteroids.Ship
{
    public class PlayerShipController : Entity, IEventReceiver<PlayerShipMoveEvent>, IEventReceiver<PlayerShootLaserEvent>
    , IEventReceiver<PlayerShipDestroyed>
    {
        [Inject] public IGameManagerService ZombieAsteroidsManagerService;
        
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
            if (ZombieAsteroidsManagerService.InProgress)
            {
                shootingEntityBehavior.ShootProjectile();
            }
        }

        public void OnEvent(PlayerShipDestroyed e)
        {
            LeanTween.rotateAround(gameObject, Vector3.forward, 360, 0.25f).setOnComplete(() =>
            {
                Destroy(gameObject);
            });
        }
    }
}
