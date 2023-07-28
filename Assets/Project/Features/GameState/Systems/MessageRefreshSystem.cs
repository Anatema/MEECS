using ME.ECS;

namespace Project.Features.GameState.Systems {

    #pragma warning disable
    using Project.Components; using Project.Modules; using Project.Systems; using Project.Markers;
    using Components; using Modules; using Systems; using Markers;
    using NativeWebSocket;
    using UnityEngine;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;

#pragma warning restore
#if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
#endif
    public sealed class MessageRefreshSystem : ISystem, IAdvanceTick, IUpdate {
        
        private GameStateFeature feature;        
        public World world { get; set; }
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);
            
        }
       
        void ISystemBase.OnDeconstruct() 
        {
            
        }
        
        void IAdvanceTick.AdvanceTick(in float deltaTime) {}
        
        void IUpdate.Update(in float deltaTime) 
        {
#if !UNITY_WEBGL || UNITY_EDITOR
            feature.WebSocket?.DispatchMessageQueue();
#endif
        }
       
        
    }
    
}