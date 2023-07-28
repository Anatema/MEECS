using ME.ECS;
using UnityEngine;

namespace Project.Features.Fruit.Components {

    public struct AppleTag : IComponent 
    { 
    }

    public struct BananaTag : IComponent
    {

    }
    public struct CreatorEntity : IComponent
    {
        [HideInInspector]
        public Entity value;
    }
    public struct AppleCreatorTag : IComponent
    {
    }
    public struct BananaCreatorTag : IComponent
    {
    }
    public struct TimedLife : IComponent 
    {
        public float value;
    }
    public struct FruitCollected : IComponent 
    {
        public int value;
    }


}