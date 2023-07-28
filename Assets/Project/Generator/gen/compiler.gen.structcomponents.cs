namespace ME.ECS {

    public static partial class ComponentsInitializer {

        static partial void InitTypeIdPartial() {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Components.CollisionComponent>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.InactiveCollisionTimer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckBodyId>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckDuclingQuantity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckEntity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DucklingInitializator>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckMovingHistory>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckRotationHistory>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckRotationSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckTilt>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.Score>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.CreatorEntity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.FruitCollected>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.TimedLife>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.GameID>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.CollidedTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.Uncollidable>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckBodyTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckHeadIntitializator>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckHeadTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.AppleCreatorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.AppleTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.BananaCreatorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.BananaTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ConnectionMessage>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ConnectorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.EndGameMessage>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ScoreMesssage>(true, true, true, false, false, false, false, false, false);

        }

        static partial void Init(State state, ref ME.ECS.World.NoState noState) {

            WorldUtilities.ResetTypeIds();

            CoreComponentsInitializer.InitTypeId();


            WorldUtilities.InitComponentTypeId<Project.Components.CollisionComponent>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.InactiveCollisionTimer>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckBodyId>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckDuclingQuantity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckEntity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DucklingInitializator>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckMovingHistory>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckRotationHistory>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckRotationSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckSpeed>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckTilt>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.Score>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.CreatorEntity>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.FruitCollected>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.TimedLife>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.GameID>(false, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.CollidedTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Components.Uncollidable>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckBodyTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckHeadIntitializator>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckHeadTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Duck.Components.DuckTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.AppleCreatorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.AppleTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.BananaCreatorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.Fruit.Components.BananaTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ConnectionMessage>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ConnectorTag>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.EndGameMessage>(true, true, true, false, false, false, false, false, false);
            WorldUtilities.InitComponentTypeId<Project.Features.GameState.Components.ScoreMesssage>(true, true, true, false, false, false, false, false, false);

            ComponentsInitializerWorld.Setup(ComponentsInitializerWorldGen.Init);
            CoreComponentsInitializer.Init(state, ref noState);


            state.structComponents.ValidateUnmanaged<Project.Components.CollisionComponent>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.InactiveCollisionTimer>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckBodyId>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckDuclingQuantity>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckEntity>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DucklingInitializator>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckMovingHistory>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckRotationHistory>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckRotationSpeed>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckSpeed>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckTilt>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.Score>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.CreatorEntity>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.FruitCollected>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.TimedLife>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Features.GameState.Components.GameID>(ref state.allocator, false);
            state.structComponents.ValidateUnmanaged<Project.Components.CollidedTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Components.Uncollidable>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckBodyTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckHeadIntitializator>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckHeadTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Duck.Components.DuckTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.AppleCreatorTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.AppleTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.BananaCreatorTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.Fruit.Components.BananaTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.GameState.Components.ConnectionMessage>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.GameState.Components.ConnectorTag>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.GameState.Components.EndGameMessage>(ref state.allocator, true);
            state.structComponents.ValidateUnmanaged<Project.Features.GameState.Components.ScoreMesssage>(ref state.allocator, true);

        }

    }

    public static class ComponentsInitializerWorldGen {

        public static void Init(Entity entity) {


            entity.ValidateDataUnmanaged<Project.Components.CollisionComponent>(false);
            entity.ValidateDataUnmanaged<Project.Components.InactiveCollisionTimer>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckBodyId>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckDuclingQuantity>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckEntity>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DucklingInitializator>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckMovingHistory>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckRotationHistory>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckRotationSpeed>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckSpeed>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckTilt>(false);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.Score>(false);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.CreatorEntity>(false);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.FruitCollected>(false);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.TimedLife>(false);
            entity.ValidateDataUnmanaged<Project.Features.GameState.Components.GameID>(false);
            entity.ValidateDataUnmanaged<Project.Components.CollidedTag>(true);
            entity.ValidateDataUnmanaged<Project.Components.Uncollidable>(true);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckBodyTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckHeadIntitializator>(true);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckHeadTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Duck.Components.DuckTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.AppleCreatorTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.AppleTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.BananaCreatorTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.Fruit.Components.BananaTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.GameState.Components.ConnectionMessage>(true);
            entity.ValidateDataUnmanaged<Project.Features.GameState.Components.ConnectorTag>(true);
            entity.ValidateDataUnmanaged<Project.Features.GameState.Components.EndGameMessage>(true);
            entity.ValidateDataUnmanaged<Project.Features.GameState.Components.ScoreMesssage>(true);

        }

    }

}
