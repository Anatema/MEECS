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
    public sealed class DucklingSpawnerSystem : ISystemFilter {
        
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
            
            return Filter.Create("Filter-DucklingSpawnerSystem")
                .With<DucklingInitializator>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            int spawnCount = entity.Get<DucklingInitializator>().spawnCount;
            Entity duckEntity;
            int alreadyCreatedDucklings = entity.Get<DuckDuclingQuantity>().value;

            for (int i = 0; i < spawnCount; i++)
            {
                duckEntity = world.AddEntity("Duckling");
                feature.ducklingConfig.Apply(duckEntity);
                duckEntity.InstantiateView(feature.viewSourceId);
                duckEntity.Get<DuckBodyId>().value = alreadyCreatedDucklings + i;
                duckEntity.Get<DuckEntity>().value = entity;
                entity.Get<DuckDuclingQuantity>().value += 1;
            }

            entity.Remove<DucklingInitializator>();
        }
    
    }
    
}