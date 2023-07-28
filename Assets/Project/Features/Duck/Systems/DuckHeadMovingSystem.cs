using ME.ECS;

namespace Project.Features.Duck.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using UnityEngine;
    using Unity.Mathematics;
    using System.Collections.Generic;

    //using ME.ECS.Collections.LowLevel;
#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class DuckHeadMovingSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-DuckHeadMovingSystem")
                .With<DuckHeadTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            var position = entity.GetPosition();
            var rotation = entity.GetRotation();

            Vector3 forward = (Quaternion)rotation * Vector3.forward;
            position += (float3)forward * deltaTime * entity.Get<DuckSpeed>().value;
            entity.SetLocalPosition(new Vector3(position.x, 0, position.y));


            Vector3[] tempArray = new Vector3[feature.positionHistory.Length];
            tempArray[0] = position;

            for (int i = 1; i < feature.positionHistory.Length; i++)
            {
                tempArray[i] = feature.positionHistory[i - 1];

            }
            feature.positionHistory = (Vector3[])tempArray.Clone();

            /*var allocator = world.GetState().allocator;

            int size = 800;

            List<Vector3> tempArray = new List<Vector3>(ref allocator, size);
            tempArray.Count = size;
            tempArray[allocator, 0] = position;

            Entity duckEntity = entity.Get<DuckEntity>().value;

            for (int i = 1; i < size; i++)
            {
                tempArray[allocator, i] = duckEntity.Get<DuckMovingHistory>().value[allocator, i - 1];

            }
            duckEntity.Get<DuckMovingHistory>().value.Dispose(ref allocator);
            duckEntity.Get<DuckMovingHistory>().value = tempArray;*/
        }
    
    }
    
}