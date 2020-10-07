namespace samalonso.zombieasteroids.Services
{
    public interface IGameManagerService
    {
        void StartGame();
        bool InProgress { get; }
    }
}
