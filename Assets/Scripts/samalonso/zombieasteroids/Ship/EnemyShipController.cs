using pEventBus;
using samalonso.zombieasteroids.Constants;
using samalonso.zombieasteroids.Events;
using UnityEngine;

namespace samalonso.zombieasteroids.Ship
{
    public class EnemyShipController : Entity, IEventReceiver<EnemyShipMoveEvent>
    {
        private float enemySpeed;
        private Vector2 enemyDirection;
        
        private void Start()
        {
            EventBus.Register(this);
        }

        private void OnDestroy()
        {
            EventBus.UnRegister(this);
        }

        protected override void Update()
        {
            direction = enemyDirection;
            speed = enemySpeed;
        
            base.Update();
        }

        public void OnEvent(EnemyShipMoveEvent e)
        {
            if (e.EnemyShipName != gameObject.name)
            {
                return;
            }
            
            enemyDirection = e.Direction;
            enemySpeed = e.Speed;
        }
        
        private void OnTriggerEnter2D(Collider2D obj)
        {
            if (obj.gameObject.CompareTag("LaserBullet"))
            {
                LeanTween.scale(gameObject, Vector2.one * 2.20f, 0.8f).setEasePunch().setOnComplete(() =>
                {
                    Destroy(gameObject);
                });
            }
            
            if (obj.gameObject.CompareTag("Player"))
            {
                EventBus<PlayerDamaged>.Raise(new PlayerDamaged
                {
                    Reason = ReasonTypeCollision.CollisionWithPlayer
                });
            }
        }
    }
}
