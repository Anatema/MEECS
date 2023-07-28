using ME.ECS;
using ME.ECS.Collections.LowLevel;
using UnityEngine;

namespace Project.Features.Duck.Components
{
    public struct Score : IComponent
    {
        public int value;
    }
    public struct DuckSpeed : IStructComponent
    {
        public float value;
    }
    public struct DuckTag : IStructComponent { }
    public struct DuckMovingHistory : IStructComponent
    {
        public List<Vector3> value;
    }
    public struct DuckRotationHistory : IStructComponent
    {
        public List<Quaternion> value;
    }
    public struct DuckDuclingQuantity : IStructComponent
    {
        public int value;
    }

    public struct DuckHeadIntitializator : IStructComponent
    {

    }

    public struct DucklingInitializator : IStructComponent
    {
        public int spawnCount;

        public DucklingInitializator(int spawnCount = 0)
        {
            this.spawnCount = spawnCount;
        }
    }

    public struct DuckTilt : IStructComponent
    {
        public float value;
    }
    public struct DuckRotationSpeed : IStructComponent
    {
        public float value;
    }
    public struct DuckEntity : IStructComponent
    {
        [HideInInspector]
        public Entity value;
    }
}