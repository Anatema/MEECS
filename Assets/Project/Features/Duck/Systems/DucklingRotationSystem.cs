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
    public sealed class DucklingRotationSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-DucklingRotationSystem")
                .With<DuckBodyTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            Quaternion newRotation = feature.rotationHistory[Mathf.Min(entity.Get<DuckBodyId>().value * 20, feature.rotationHistory.Length - 1)];
            entity.SetLocalRotation(newRotation);

            /*var allocator = world.GetState().allocator;
            List<Quaternion> tempArray = new List<Quaternion>(ref allocator, 200);
            tempArray.CopyFrom(ref allocator, entity.Get<DuckEntity>().value.Get<DuckRotationHistory>().value);

            Quaternion newPosition = tempArray[allocator, Mathf.Min(entity.Get<DuckBodyId>().value * 15, tempArray.Count - 1)];
            entity.SetLocalRotation(newPosition);
            tempArray.Dispose(ref allocator);*/
        }
    
    }
    
}