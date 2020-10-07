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
        private EngineFlareBehavior engineFlareBehavior;

        private void Start()
        {
            EventBus.Register(this);
            shootingEntityBehavior = GetComponent<ShootingEntityBehavior>();
            engineFlareBehavior = GetComponent<EngineFlareBehavior>();
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

            OnMovementFlare(e.Direction);
        }

        private void OnMovementFlare(Vector2 direction)
        {
            if (direction.y == 1)
            {
                engineFlareBehavior.ShowFlare();
            }
            else
            {
                engineFlareBehavior.HideFlare();
            }
        }

        public void OnEvent(PlayerShootLaserEvent e)
        {
            if (!ZombieAsteroidsManagerService.InProgress)
            {
                return;
            }
            
            shootingEntityBehavior.ShootProjectile();
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
