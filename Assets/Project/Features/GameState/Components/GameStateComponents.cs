using ME.ECS;

namespace Project.Features.GameState.Components {

    public struct GameID : IComponent 
    {
        public int value;
    }
    public struct ConnectorTag : IComponent
    {

    }
    public struct ConnectionMessage : IComponent
    {        
    }

    public struct ScoreMesssage : IComponent
    {
    }

    public struct EndGameMessage : IComponent 
    { 
    }
}