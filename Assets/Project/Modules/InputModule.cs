using ME.ECS;

namespace Project.Modules {
    
    using Components; using Modules; using Systems; using Features; using Markers;
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class InputModule : IModule, IUpdate {
        
        public World world { get; set; }
        
        void IModuleBase.OnConstruct() {}
        
        void IModuleBase.OnDeconstruct() {}
        
        void IUpdate.Update(in float deltaTime) 
        {
            //float markerData = UnityEngine.Input.GetAxis("Horizontal");
            //this.world.AddMarker(new HorizontalMovementMarker() { Input = markerData });
        }
        
    }
    
}
