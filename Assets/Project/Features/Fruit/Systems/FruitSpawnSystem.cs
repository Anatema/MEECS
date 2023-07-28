using ME.ECS;

namespace Project.Features.Fruit.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using UnityEngine;
#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class FruitSpawnSystem : ISystemFilter {
        
        private FruitFeature feature;
        
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

            return Filter.Create("Filter-FruitSpawnSystem")
                .With<AppleCreatorTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            var appleEntity = world.AddEntity("Apple");
            feature.apleConfig.Apply(appleEntity);
            appleEntity.InstantiateView(feature.appleSourceId);
            appleEntity.Get<CreatorEntity>().value = entity;
            float horzontal = world.GetRandomRange(-6, 6);
            float vertical = world.GetRandomRange(-6, 6);
            appleEntity.SetLocalPosition(new Vector3(horzontal, 0, vertical));
            appleEntity.Remove<Uncollidable>();

            entity.Remove<AppleCreatorTag>();
        
        }
    
    }
    
}