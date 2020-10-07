using samalonso.zombieasteroids.Services;
using UnityEngine;
using Zenject;

namespace samalonso.zombieasteroids.Behaviors
{
    public class LevelBehavior : MonoBehaviour
    {
        public GameObject enemyPrefab;
        public int enemiesToSpawn;

        [Inject] public IGameAIEnemyService GameAIEnemyService;
        
        void Start()
        {
            SpawnEnemies();
            GameAIEnemyService.StartAI();
        }
        
       private void SpawnEnemies()
       {
           for (var i = 0; i < enemiesToSpawn; ++i)
           {
               var position = Utils.Helpers.GetRandomVectorInterval(-300, 500);
               
               var go = SpawnEnemy(position);
               
               go.name = $"{Constants.LevelContants.ENEMY_PREFIX_NAME}{i}";
           }
       }

       private GameObject SpawnEnemy(Vector2 position)
       {
           return Instantiate(enemyPrefab, position, transform.rotation, gameObject.transform);
       }
    }
}

