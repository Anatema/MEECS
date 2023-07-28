using ME.ECS;

namespace Project.Features.Board.Systems {

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
    public sealed class TeleportationSystem : ISystemFilter {
        
        private BoardFeature feature;
        
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

            return Filter.Create("Filter-TeleportationSystem")
                .With<Duck.Components.DuckBodyTag>()
                .Push();
            
        }
    
        void ISystemFilter.AdvanceTick(in Entity entity, in float deltaTime) 
        {
            Vector3 position = entity.GetLocalPosition();
            float nextPositionX = position.x;
            float nextPositionY = position.z;

            if(nextPositionX > feature.MaxBorder.x)
            {
                nextPositionX = feature.MinBorder.x + nextPositionX - feature.MaxBorder.x; 
            }
            if (nextPositionX < feature.MinBorder.x)
            {
                nextPositionX = feature.MaxBorder.x + nextPositionX - feature.MinBorder.x;
            }

            if (nextPositionY > feature.MaxBorder.y)
            {
                nextPositionY = feature.MinBorder.y + nextPositionY - feature.MaxBorder.y;
            }
            if (nextPositionY < feature.MinBorder.y)
            {
                nextPositionY = feature.MaxBorder.y + nextPositionY - feature.MinBorder.y;
            }

            entity.SetLocalPosition(new Vector3(nextPositionX, 0, nextPositionY));
        }
    
    }
    
}