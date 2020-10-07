using System;
using System.Collections.Generic;
using UnityEngine;

namespace samalonso.zombieasteroids.Services
{
    public class GameEntitiesPositionService : IPositionService
    {
        private readonly Dictionary<string, Vector2> entitiesPositionsByKey = new Dictionary<string, Vector2>();

        public Dictionary<string, Vector2> GetAllEntities() => entitiesPositionsByKey;
        
        public void RegisterEntityPosition(string entityName, Vector2 entityPosition)
        {
            entitiesPositionsByKey[entityName] = entityPosition;
        }

        public Vector2 GetEntityPosition(string entityName)
        {
            if (!entitiesPositionsByKey.ContainsKey(entityName))
            {
                throw new Exception($"Position for entity {entityName} not found!");
            }

            return entitiesPositionsByKey[entityName];
        }
    }
}


