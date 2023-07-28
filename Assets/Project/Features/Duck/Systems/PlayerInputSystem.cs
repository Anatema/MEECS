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
    public sealed class PlayerInputSystem : ISystem, IAdvanceTick, IUpdate {
        
        private DuckFeature feature;
        private RPCId InputRPCid;
        private Filter filter;
        public World world { get; set; }
        
        void ISystemBase.OnConstruct() {
            
            this.GetFeature(out this.feature);

            Filter.Create("Collision-Filter")
               .With<DuckHeadTag>()
               .Push(ref filter);

            var network = world.GetModule<NetworkModule>();
            network.RegisterObject(this);

            InputRPCid = network.RegisterRPC(new System.Action<float>(ChangeTilt).Method);
        }
        
        void ISystemBase.OnDeconstruct() {}
        
        void IAdvanceTick.AdvanceTick(in float deltaTime) {}
        
        void IUpdate.Update(in float deltaTime) 
        {

            if (world.GetMarker(out HorizontalMovementMarker marker))
            {
                var network = world.GetModule<NetworkModule>();
                network.RPC(this, InputRPCid, marker.Input);
            }
        }
        void ChangeTilt(float value)
        {
            Entity headEntity;
            foreach (var entity in filter)
            {
                headEntity = entity;
                headEntity.Get<DuckTilt>().value = value;

                break;
            }

        }
    }
    
}