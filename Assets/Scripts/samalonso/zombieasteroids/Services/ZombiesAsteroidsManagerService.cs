using pEventBus;
using samalonso.zombieasteroids.Constants;
using samalonso.zombieasteroids.Events;

namespace samalonso.zombieasteroids.Services
{
    public class ZombiesAsteroidsManagerService : IGameManagerService, IEventReceiver<PlayerDamaged>
    {
        private IGameAIEnemyService chasePlayerAIService;
        private IPositionService gameEntitiesPositionService;
        internal bool isGameInProgress;
        
        public ZombiesAsteroidsManagerService(IGameAIEnemyService chasePlayerAIService, IPositionService gameEntitiesPositionService)
        {
            this.chasePlayerAIService = chasePlayerAIService;
            this.gameEntitiesPositionService = gameEntitiesPositionService;
            
            EventBus.Register(this);
        }
        
        public void StartGame()
        {
            chasePlayerAIService.StartAI();

            isGameInProgress = true;
        }

        public bool InProgress => isGameInProgress;

        public void OnEvent(PlayerDamaged e)
        {
            if (e.Reason == ReasonTypeCollision.CollisionWithPlayer)
            {
                EndGame();
            }
        }

        internal void EndGame()
        {
            EventBus.UnRegister(this);
            
            chasePlayerAIService.EndAI();

            isGameInProgress = false;
            
            EventBus<PlayerShipDestroyed>.Raise(new PlayerShipDestroyed());
        }
    }
}
