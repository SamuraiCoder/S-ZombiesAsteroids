using System.Collections.Generic;
using pEventBus;
using samalonso.zombieasteroids.Events;
using samalonso.zombieasteroids.Utils;
using UnityEngine;
using Zenject;

namespace samalonso.zombieasteroids.Services
{
    public class ChasePlayerAIService : IGameAIEnemyService, ITickable
    {
        [Inject] public IPositionService gameEntitiesPositionService;
        
        private float lastCheck;
        private bool makeAIwork;

        public ChasePlayerAIService(IPositionService gameEntitiesPositionService)
        {
            this.gameEntitiesPositionService = gameEntitiesPositionService;
        }
        
        public void StartAI()
        {
            makeAIwork = true;
        }

        public void EndAI()
        {
            makeAIwork = false;
            
            StopAllShips();
        }

        private void StopAllShips()
        {
            var allEntitiesPositions = gameEntitiesPositionService.GetAllEntities();

            foreach (var entity in allEntitiesPositions)
            {
                EventBus<EnemyShipMoveEvent>.Raise(new EnemyShipMoveEvent
                {
                    EnemyShipName = entity.Key,
                    Direction = Vector2.zero,
                    Speed = 0.0f
                });
            }
        }

        public void Tick()
        {
            if (!makeAIwork)
            {
                return;
            }
            
            lastCheck += Time.deltaTime;

            if (lastCheck < Constants.EnemyAI.CHECK_FOR_CHASE_AI_EXPIRATION_TIME)
            {
                return;
            }

            lastCheck = 0.0f;

            BullyPlayer();
        }

        private void BullyPlayer()
        {
            var allEntitiesPositions = gameEntitiesPositionService.GetAllEntities();

            foreach (var entity in allEntitiesPositions)
            {
                var enemyDirection = OnCalculateEnemyDirection(entity);
                
                EventBus<EnemyShipMoveEvent>.Raise(new EnemyShipMoveEvent
                {
                    EnemyShipName = entity.Key,
                    Direction = enemyDirection,
                    Speed = Helpers.RandomNumbersInterval(Constants.EnemyAI.MIN_SPEED_ENEMY, Constants.EnemyAI.MAX_SPEED_ENEMY)
                });
            }
        }

        private Vector2 OnCalculateEnemyDirection(KeyValuePair<string, Vector2> entity)
        {
            var playerPosition = gameEntitiesPositionService.GetEntityPosition(Constants.EnemyAI.PLAYER_SHIP_NAME);
            var enemyPosition = gameEntitiesPositionService.GetEntityPosition(entity.Key);

            var angleBetweenEnemyAndPlayer = Helpers.AngleBetweenVector2(enemyPosition, playerPosition);
            
            return GetDirectionVectorFromAngle(angleBetweenEnemyAndPlayer);
        }

        private Vector2 GetDirectionVectorFromAngle(float angleBetweenEnemyAndPlayer)
        {
            var direction = Vector2.zero;
            switch (angleBetweenEnemyAndPlayer)
            {
                case 0:
                    direction = Vector2.right;
                    break;
                case 90.0f:
                    direction = Vector2.up;
                    break;
                case 180.0f:
                    direction = Vector2.left;
                    break;
                case 270.0f:
                    direction = Vector2.down;
                    break;
                default:
                {
                    if (angleBetweenEnemyAndPlayer > 0 && angleBetweenEnemyAndPlayer < 90)
                    {
                        direction = new Vector2(0.5f, 0.5f); 
                    }
                    else if (angleBetweenEnemyAndPlayer > 90 && angleBetweenEnemyAndPlayer < 180)
                    {
                        direction = new Vector2(-0.5f, 0.5f);
                    } 
                    else if (angleBetweenEnemyAndPlayer > 180 && angleBetweenEnemyAndPlayer < 270)
                    {
                        direction = new Vector2(-0.5f, -0.5f);;
                    }
                    else if (angleBetweenEnemyAndPlayer > 270 && angleBetweenEnemyAndPlayer < 359)
                    {
                        direction = new Vector2(0.5f, -0.5f);;
                    }

                    break;
                }
            }
            
            return direction;
        }
    }
}
