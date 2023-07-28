using ME.ECS;

namespace Project.Features.Duck.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using UnityEngine;
    using ME.ECS.Collections.LowLevel;
#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class DuckHeadRotationSystem : ISystemFilter {
        
        private DuckFeature feature;
        
        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        #if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
        #endif
        Filter ISystemFilter.filter { get; set; }
        Filter ISystemFilter.CreateFilter() {
            
            return Filter.Create("Filter-DuckHeadRotationSystem")
                .With<DuckHeadTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            var rotation = entity.GetRotation();
            var tilt = entity.Get<DuckTilt>().value;
            var speed = entity.Get<DuckRotationSpeed>().value;
            entity.SetRotation(rotation * Quaternion.Euler(0, tilt * speed * deltaTime, 0));

            Quaternion[] tempArray = new Quaternion[feature.rotationHistory.Length];
            tempArray[0] = entity.GetLocalRotation();

            for (int i = 1; i < feature.rotationHistory.Length; i++)
            {
                tempArray[i] = feature.rotationHistory[i - 1];

            }
            feature.rotationHistory = (Quaternion[])tempArray.Clone();

            /*var allocator = world.GetState().allocator;
            int size = 800;

            List<Quaternion> tempArray = new List<Quaternion>(ref allocator, size);
            tempArray.Count = size;
            tempArray[allocator, 0] = entity.GetLocalRotation();

            Entity duckEntity = entity.Get<DuckEntity>().value;

            for (int i = 1; i < size; i++)
            {
                tempArray[allocator, i] = duckEntity.Get<DuckRotationHistory>().value[allocator, i - 1];

            }
            duckEntity.Get<DuckRotationHistory>().value.Dispose(ref allocator);
            duckEntity.Get<DuckRotationHistory>().value = tempArray;*/
        }
    
    }
    
}