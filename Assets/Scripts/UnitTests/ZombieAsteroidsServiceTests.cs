using Moq;
using NUnit.Framework;
using samalonso.zombieasteroids.Services;

namespace Tests
{
    public class ZombieAsteroidsServiceTests
    {
        [Test]
        public void ZombieAsteroidsManagerServiceStart()
        {
            var positionServiceMock = new Mock<IPositionService>();
            var chasePlayerAIService = new Mock<IGameAIEnemyService>();
            var zombieAsteroidsManagerService = new ZombiesAsteroidsManagerService(chasePlayerAIService.Object, positionServiceMock.Object);
            
            zombieAsteroidsManagerService.StartGame();
            
            Assert.AreEqual(true, zombieAsteroidsManagerService.isGameInProgress);
        }
        
        [Test]
        public void ZombieAsteroidsManagerServiceStop()
        {
            var positionServiceMock = new Mock<IPositionService>();
            var chasePlayerAIService = new Mock<IGameAIEnemyService>();
            var zombieAsteroidsManagerService = new ZombiesAsteroidsManagerService(chasePlayerAIService.Object, positionServiceMock.Object);
            
            zombieAsteroidsManagerService.StartGame();
            zombieAsteroidsManagerService.EndGame();
            
            Assert.AreEqual(false, zombieAsteroidsManagerService.isGameInProgress);
        }
    }
}
