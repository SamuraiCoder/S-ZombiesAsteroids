using pEventBus;
using samalonso.zombieasteroids.Events;
using UnityEngine;

namespace samalonso.zombieasteroids.ship
{
    public class PlayerShipInteractor : MonoBehaviour
    {
        private void Update()
        {
            OnPlayerKeyboardMovementInput();
            
            OnPlayerKeyboardShootInput();
        }
        
        private void OnPlayerKeyboardMovementInput()
        {
            var directionVector = Vector2.zero;
            
            if (Input.GetKey(KeyCode.W))
            {
                directionVector += Vector2.up;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                directionVector += Vector2.down;
            }
            
            if (Input.GetKey(KeyCode.A))
            {
                directionVector += Vector2.left;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                directionVector += Vector2.right;
            }
            
            EventBus<PlayerShipMoveEvent>.Raise(new PlayerShipMoveEvent
            {
                Direction = directionVector,
            });
        }
        
        private void OnPlayerKeyboardShootInput()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
               EventBus<PlayerShootLaserEvent>.Raise(new PlayerShootLaserEvent());
            }
        }
    }
}
