using ME.ECS;

namespace Project.Features.Duck.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using ME.ECS.Collections.LowLevel;
    using UnityEngine;
#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class DucklingMovingSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-DucklingMovingSystem")
                .With<DuckBodyId>()
                .With<DuckBodyTag>()
                .Push();

        }
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {

            Vector3 newPosition = feature.positionHistory[Mathf.Min(entity.Get<DuckBodyId>().value * 20, feature.positionHistory.Length - 1)];
            entity.SetLocalPosition(newPosition);

            /*var allocator = world.GetState().allocator;
            List<Vector3> tempArray = new List<Vector3>(ref allocator, 200);
            tempArray.CopyFrom(ref allocator, entity.Get<DuckEntity>().value.Get<DuckMovingHistory>().value);
            //entity.Get<DuckEntity>().value.Get<DuckMovingHistory>().value.

            Vector3 newPosition = tempArray[allocator, Mathf.Min(entity.Get<DuckBodyId>().value * 20, tempArray.Count - 1)];
            entity.SetLocalPosition(newPosition);
            tempArray.Dispose(ref allocator);*/
        }
    
    }
    
}