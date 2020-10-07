using pEventBus;
using samalonso.zombieasteroids.Constants;

namespace samalonso.zombieasteroids.Events
{
    public struct PlayerDamaged : IEvent
    {
        public ReasonTypeCollision Reason { get; set; }
    }
}

