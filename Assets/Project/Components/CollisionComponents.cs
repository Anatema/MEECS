using ME.ECS;
using UnityEngine;

namespace Project.Components {

    public struct CollisionComponent : IComponent 
    {
        public float radius;
    }
    
    public struct Uncollidable : IComponent { }

    public struct CollidedTag : IComponent { }

    public struct InactiveCollisionTimer : IComponent
    {
        public float timer;
    }
}