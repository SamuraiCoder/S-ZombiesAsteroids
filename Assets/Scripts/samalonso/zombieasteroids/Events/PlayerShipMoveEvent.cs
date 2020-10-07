using pEventBus;
using UnityEngine;

namespace samalonso.zombieasteroids.Events
{
    public struct PlayerShipMoveEvent : IEvent
    {
        public Vector2 Direction { get; set; }
    }
}

