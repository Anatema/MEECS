using ME.ECS;

namespace Project.Features.Duck.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    #pragma warning restore
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class DuckHeadSpawnerSystem : ISystemFilter {
        
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

            return Filter.Create("Filter-DuckHeadSpawnerSystem")
                .With<DuckHeadIntitializator>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            var duckEntity = world.AddEntity("DuckHead");
            feature.duckHeadConfig.Apply(duckEntity);
            duckEntity.InstantiateView(feature.viewSourceId);
            duckEntity.Get<DuckEntity>().value = entity;
            //duckEntity.Get<>


            entity.Get<DuckDuclingQuantity>().value += 1;
            entity.Remove<DuckHeadIntitializator>();


        }
    
    }
    
}