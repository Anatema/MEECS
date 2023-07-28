using ME.ECS;

namespace Project.Features.Duck.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using UnityEngine;
    using Project.Features.Fruit.Components;
#pragma warning restore

#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class DuckCollisionSystem : ISystemFilter {
        
        private DuckFeature feature;
        private Filter _collisionFilter;


        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            Filter.Create("Collision-Filter")
                .With<CollisionComponent>()
                .Without<Uncollidable>()
                .Push(ref _collisionFilter);

        }
        
        void ISystemBase.OnDeconstruct() {}
        
        #if !CSHARP_8_OR_NEWER
        bool ISystemFilter.jobs => false;
        int ISystemFilter.jobsBatchCount => 64;
        #endif
        Filter ISystemFilter.filter { get; set; }
        Filter ISystemFilter.CreateFilter() {
            
            return Filter.Create("Filter-DuckCollisionSystem")
                .With<DuckHeadTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime)         
        {
            ref readonly var headRadius = ref entity.Read<CollisionComponent>().radius;
            Vector3 position = entity.GetLocalPosition();

            foreach (var coll in _collisionFilter)
            {
                ref readonly var radius = ref coll.Read<CollisionComponent>().radius;
                var collPosition = coll.GetPosition();

                var distance = Vector3.Distance(position, collPosition);
                if (distance < headRadius)
                {
                    CollisionScored(coll, entity);
                    break;
                }
            }
        }

        private void CollisionScored(Entity collision, Entity entity)
        {
            if (collision.Has<AppleTag>())
            {
                entity.Get<DuckEntity>().value.Set(new DucklingInitializator(1));
                collision.Set<Uncollidable>();
                collision.Set<CollidedTag>();
                world.GetSharedData<Score>().value += 1;
                feature.ScoreChanged?.Execute();
                DuckFeature.ScoreChangedEvent?.Invoke(world.GetSharedData<Score>().value);
            }
            if (collision.Has<DuckBodyTag>())
            {
                feature.GameEnded?.Execute();
                entity.Destroy();
            }
            if (collision.Has<BananaTag>())
            {
                entity.Get<DuckEntity>().value.Set(new DucklingInitializator(2));
                world.GetSharedData<Score>().value += 2;
                feature.ScoreChanged?.Execute();
                DuckFeature.ScoreChangedEvent?.Invoke(world.GetSharedData<Score>().value);
                collision.Destroy();
            }
        }
    
    }
    
}