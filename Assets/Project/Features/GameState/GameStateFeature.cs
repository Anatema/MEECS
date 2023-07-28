using ME.ECS;

namespace Project.Features {

    using Components; using Modules; using Systems; using Features; using Markers;
    using GameState.Components; using GameState.Modules; using GameState.Systems; using GameState.Markers;
    using ME.ECS.Serializer;
    using NativeWebSocket;
    using UnityEngine;
    using Newtonsoft.Json.Linq;
    using Project.Features.Duck.Components;

    namespace GameState.Components {}
    namespace GameState.Modules {}
    namespace GameState.Systems {}
    namespace GameState.Markers {}
    
    #if ECS_COMPILE_IL2CPP_OPTIONS
    [Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.NullChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.ArrayBoundsChecks, false),
     Unity.IL2CPP.CompilerServices.Il2CppSetOptionAttribute(Unity.IL2CPP.CompilerServices.Option.DivideByZeroChecks, false)]
    #endif
    public sealed class GameStateFeature : Feature
    {
        public string Url;
        public GlobalEvent GameStarted;
        public GlobalEvent ScoreChanged;
        public GlobalEvent GameEnded;
        public WebSocket WebSocket; 
        private RPCId onRecivedMessage;
        private RPCId onScoreChanged;
        private RPCId onGameEnded;
        private NetworkModule network;
        protected override void OnConstruct() 
        {    
            AddSystem<MessageRefreshSystem>();

            network = world.GetModule<NetworkModule>();
            network.RegisterObject(this);

            onRecivedMessage = network.RegisterRPC(new System.Action<JObject>(SortMessages).Method);
            onScoreChanged = network.RegisterRPC(new System.Action(SendScore).Method);
            onGameEnded = network.RegisterRPC(new System.Action(EndGame).Method);

            ScoreChanged.Subscribe(OnScoreChangedRPC);
            GameEnded.Subscribe(OnGameEndedRPC);
        }
        protected override void OnConstructLate()
        {
            var connectionEntity = world.AddEntity("OnConnectedToEntity");
            connectionEntity.Set(new ConnectorTag());
            Connect();
        }
        private async void Connect()
        {
            WebSocket = new WebSocket(Url);

            WebSocket.OnOpen += OnOpen;
            WebSocket.OnError += OnError;
            WebSocket.OnClose += OnClose;
            WebSocket.OnMessage += OnMessage;

            await WebSocket.Connect();
        }

        private void OnOpen()
        {
            CreateGame();
            
        }
        private void OnError(string errorMsg)
        {
            Debug.Log(errorMsg);
        }

        private void OnClose(WebSocketCloseCode closeCode)
        {
            Debug.Log(closeCode);
        }

        private void OnMessage(byte[] data)
        {
            JObject jObject = JObject.Parse(System.Text.Encoding.UTF8.GetString(data));
            var network = world.GetModule<NetworkModule>();
            network.RPC(this, onRecivedMessage, jObject);
        }
        protected override void OnDeconstruct()
        {
            WebSocket.OnOpen -= OnOpen;
            WebSocket.OnError -= OnError;
            WebSocket.OnClose -= OnClose;
            WebSocket.OnMessage -= OnMessage;

            ScoreChanged.Unsubscribe(OnScoreChangedRPC);
            GameEnded.Unsubscribe(OnGameEndedRPC);
            network.UnRegisterRPC(onRecivedMessage);
            network.UnRegisterRPC(onScoreChanged);
            network.UnRegisterRPC(onGameEnded);
         }
        private void OnScoreChangedRPC(in Entity entity)
        {
            network.RPC(this, onScoreChanged);
        }
        private void OnGameEndedRPC(in Entity entity)
        {
            network.RPC(this, onGameEnded);
        }
        private void SortMessages(JObject message)
        {
           
            switch (message["type"].Value<string>())
            {
                case "error":
                    Debug.Log(message["payload"]["errorText"].Value<string>());
                    break;

                case "game-created":
                    Debug.Log("Game succsesfuly created");
                    int index = message["payload"]["id"].Value<int>();
                    SetId(index);
                    GameStarted.Execute();
                    break;

                case "game-ended":
                    Debug.Log(message);
                    Unsubscribe();
                    break;

                default:
                    Debug.Log("Unknown value");
                    break;
            }
        }
        async void CreateGame()
        {

            JObject jObject = new JObject();
            jObject.Add("type", new JValue("create-game"));

            if (WebSocket.State == WebSocketState.Open)
            {
                await WebSocket.SendText(jObject.ToString());
            }
        }
        async void SendScore()
        {
            JObject payload = new JObject();
            payload.Add("appleCount", new JValue(GetScore()));
            payload.Add("snakeLength", new JValue(GetSnakeSize()));
            payload.Add("game_id", new JValue(GetGameID()));

            JObject jObject = new JObject();
            jObject.Add("type", new JValue("collect-apple"));
            jObject.Add("payload", payload);

            if (WebSocket.State == WebSocketState.Open)
            {
                await WebSocket.SendText(jObject.ToString());
            }
        }
        async void EndGame()
        {
            Debug.Log("game Ednded");

            JObject payload = new JObject();
            payload.Add("game_id", new JValue(GetGameID()));

            JObject jObject = new JObject();
            jObject.Add("type", new JValue("end-game"));
            jObject.Add("payload", payload);

            if (WebSocket.State == WebSocketState.Open)
            {
                await WebSocket.SendText(jObject.ToString());
            }

            
        }
        private void Unsubscribe()
        {
            ScoreChanged.Unsubscribe(OnScoreChangedRPC);
            GameEnded.Unsubscribe(OnGameEndedRPC);
            network.UnRegisterRPC(onRecivedMessage);
            network.UnRegisterRPC(onScoreChanged);
            network.UnRegisterRPC(onGameEnded);
        }
        private void SetId(int id)
        {
            world.SetSharedData(new GameID() { value = id });
        }
        private int GetScore()
        {
            return world.GetSharedData<Score>().value;

        }
        private int GetGameID()
        {
            return world.GetSharedData<GameID>().value;

        }
        private int GetSnakeSize()
        {
            return world.GetSharedData<Score>().value + 2;
        }
    }

}