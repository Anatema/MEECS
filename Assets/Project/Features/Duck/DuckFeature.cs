using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Duck.Components; using Duck.Modules; using Duck.Systems; using Duck.Markers;
    using ME.ECS.DataConfigs;
    using Unity.Collections;
    using UnityEngine;
    using System.Collections.Generic;
    using Project.Features.GameState.Components;
    using UnityEngine.Events;

    //using ME.ECS.Collections.LowLevel;

    namespace Duck.Components {}
    namespace Duck.Modules {}
    namespace Duck.Systems {}
    namespace Duck.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif

    public sealed class DuckFeature : Feature {

        public DataConfig duckConfig;
        public DataConfig duckHeadConfig;
        public DataConfig ducklingConfig;

        public Duck.Views.DuckView viewSource;
        public ViewId viewSourceId;

        public Vector3[] positionHistory = new Vector3[800];
        public Quaternion[] rotationHistory = new Quaternion[800];

        public GlobalEvent GameStarted;
        public GlobalEvent ScoreChanged;
        public GlobalEvent GameEnded;

        private RPCId onGameStarted;
        private NetworkModule network;

        public static UnityEvent<int> ScoreChangedEvent = new UnityEvent<int>();
        protected override void OnConstruct() 
        {
            this.viewSourceId = this.world.RegisterViewSource(viewSource);

            AddSystem<DuckCollisionSystem>();
            AddSystem<DuckHeadSpawnerSystem>();
            AddSystem<DucklingSpawnerSystem>();
            AddSystem<PlayerInputSystem>();
            AddSystem<DuckHeadRotationSystem>();
            AddSystem<DuckHeadMovingSystem>();
            AddSystem<DucklingMovingSystem>();
            AddSystem<DucklingRotationSystem>();
            AddSystem<CollisionInactivitySystem>();

            
        }
        protected override void OnConstructLate()
        {
            network = world.GetModule<NetworkModule>();
            network.RegisterObject(this);

            onGameStarted = network.RegisterRPC(new System.Action(CreateDuckEntity).Method);
            GameStarted.Subscribe(CreateDuckEntityAdapter);
            world.SetSharedData(new Score() { value = 0 });

        }
        private void CreateDuckEntityAdapter(in Entity entity)
        {
            network.RPC(this, onGameStarted);            
        }
        private void CreateDuckEntity()
        {
            var duckEntity = world.AddEntity("Duck");
            duckConfig.Apply(duckEntity);

            GameStarted.Unsubscribe(CreateDuckEntityAdapter);
            network.UnRegisterRPC(onGameStarted);
            /*var allocator = world.GetState().allocator;
            duckEntity.Get<DuckMovingHistory>().value = new List<Vector3>(ref allocator, 200);
            duckEntity.Get<DuckMovingHistory>().value.Count = 800;

            duckEntity.Get<DuckRotationHistory>().value = new List<Quaternion>(ref allocator, 200);
            duckEntity.Get<DuckRotationHistory>().value.Count = 800;*/

        }
        protected override void OnDeconstruct()
        {
            
        }

    }

}