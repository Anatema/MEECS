using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using Fruit.Components; using Fruit.Modules; using Fruit.Systems; using Fruit.Markers;
    using ME.ECS.DataConfigs;

    namespace Fruit.Components {}
    namespace Fruit.Modules {}
    namespace Fruit.Systems {}
    namespace Fruit.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class FruitFeature : Feature 
    {
        public DataConfig apleConfig;
        public DataConfig bananaConfig;
        public DataConfig fruitCreatorConfig;

        public Fruit.Views.FruitView appleSource;
        public ViewId appleSourceId;

        public Fruit.Views.FruitView bananaSource;
        public ViewId bananaSourceId;
        protected override void OnConstruct()
        {
            appleSourceId = world.RegisterViewSource(appleSource);
            bananaSourceId = world.RegisterViewSource(bananaSource);
            AddSystem<FruitSpawnSystem>();
            AddSystem<FruitRespawnSystem>();
            AddSystem<BananaSpawnSystem>();
            AddSystem<TimedLifeSystem>();
        }
        protected override void OnConstructLate()
        {
            var fruitCreatorEntity = world.AddEntity("FruitController");
            fruitCreatorConfig.Apply(fruitCreatorEntity);
        }

        protected override void OnDeconstruct() {
            
        }

    }

}