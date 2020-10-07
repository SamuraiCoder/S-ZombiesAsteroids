using samalonso.zombieasteroids.Services;
using UnityEngine;
using Zenject;

namespace samalonso.zombieasteroids.Behaviors
{
    public class PositionNotifierBehavior : MonoBehaviour
    {
        [Inject] public IPositionService gameEntitiesPositionService;
        
        private Vector2 lastEntityPosition;
        
        void Update()
        {
            if (lastEntityPosition == (Vector2)transform.position)
            {
                return;
            }

            lastEntityPosition = transform.position;
            
            RegisterEntityPosition();
        }

        private void RegisterEntityPosition()
        {
            gameEntitiesPositionService.RegisterEntityPosition(gameObject.name, transform.position);
        }
    }
}
