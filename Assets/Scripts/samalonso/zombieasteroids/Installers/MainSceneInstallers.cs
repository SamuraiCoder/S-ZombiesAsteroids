using samalonso.zombieasteroids.Services;
using UnityEngine;
using Zenject;

namespace samalonso.zombieasteroids.Installers
{
    public class MainSceneInstallers : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<string>().FromInstance("Welcome to S-Zombies-Asteroids! this msg tells Zenject is working well");
            Container.Bind<Greeter>().AsSingle().NonLazy();
            Container.Bind<IPositionService>().To<GameEntitiesPositionService>().AsSingle().NonLazy();
            Container.Bind(typeof(IGameAIEnemyService), typeof(ITickable)).To<ChasePlayerAIService>().AsSingle();
        }
    }
    public class Greeter
    {
        public Greeter(string message)
        {
            Debug.Log(message);
        }
    }
}
