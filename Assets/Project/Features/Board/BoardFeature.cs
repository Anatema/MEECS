using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Board.Components; using Board.Modules; using Board.Systems; using Board.Markers;
    using UnityEngine;

    namespace Board.Components {}
    namespace Board.Modules {}
    namespace Board.Systems {}
    namespace Board.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class BoardFeature : Feature {

        public Vector2 MaxBorder;
        public Vector2 MinBorder;
        protected override void OnConstruct() 
        {
            AddSystem<TeleportationSystem>();

            
        }

        protected override void OnDeconstruct() {
            
        }

    }

}