﻿using UnityEngine;

namespace samalonso.zombieasteroids.Ship
{
    public abstract class Entity : MonoBehaviour
    {
        protected float speed;
        protected Vector2 direction;

        protected virtual void Update()
        {
            MoveEntity();
        }
        
        private void MoveEntity()
        {
            transform.Translate(direction * speed * Time.deltaTime);
        }
    }
}
