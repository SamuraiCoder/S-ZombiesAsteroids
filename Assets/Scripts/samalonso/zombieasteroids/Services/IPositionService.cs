using System.Collections.Generic;
using UnityEngine;

namespace samalonso.zombieasteroids.Services
{
    public interface IPositionService
    {
        void RegisterEntityPosition(string entityName, Vector2 entityPosition);
        void UnRegisterEntityPosition(string entityName);
        Vector2 GetEntityPosition(string entityName);
        Dictionary<string, Vector2> GetAllEntities();
    }
}

