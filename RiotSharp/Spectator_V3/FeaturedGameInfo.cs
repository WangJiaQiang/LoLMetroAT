//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Spectator_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // 
    public class FeaturedGameInfo
    {
        
        // The ID of the game
        [JsonProperty("gameId")]
        private long _gameId;
        
        // The game start time represented in epoch milliseconds
        [JsonProperty("gameStartTime")]
        private long _gameStartTime;
        
        // The ID of the platform on which the game is being played
        [JsonProperty("platformId")]
        private string _platformId;
        
        // The game mode
        [JsonProperty("gameMode")]
        private string _gameMode;
        
        // The ID of the map
        [JsonProperty("mapId")]
        private long _mapId;
        
        // The game type
        [JsonProperty("gameType")]
        private string _gameType;
        
        // Banned champion information
        [JsonProperty("bannedChampions")]
        private List<BannedChampion> _bannedChampions;
        
        // The observer information
        [JsonProperty("observers")]
        private Observer _observers;
        
        // The participant information
        [JsonProperty("participants")]
        private List<Participant> _participants;
        
        // The amount of time in seconds that has passed since the game started
        [JsonProperty("gameLength")]
        private long _gameLength;
        
        // The queue type (queue types are documented on the Game Constants page)
        [JsonProperty("gameQueueConfigId")]
        private long _gameQueueConfigId;
        
        // The ID of the game
        public long GameId
        {
            get
            {
                return this._gameId;
            }
            set
            {
                this._gameId = value;
            }
        }
        
        // The game start time represented in epoch milliseconds
        public long GameStartTime
        {
            get
            {
                return this._gameStartTime;
            }
            set
            {
                this._gameStartTime = value;
            }
        }
        
        // The ID of the platform on which the game is being played
        public string PlatformId
        {
            get
            {
                return this._platformId;
            }
            set
            {
                this._platformId = value;
            }
        }
        
        // The game mode
        public string GameMode
        {
            get
            {
                return this._gameMode;
            }
            set
            {
                this._gameMode = value;
            }
        }
        
        // The ID of the map
        public long MapId
        {
            get
            {
                return this._mapId;
            }
            set
            {
                this._mapId = value;
            }
        }
        
        // The game type
        public string GameType
        {
            get
            {
                return this._gameType;
            }
            set
            {
                this._gameType = value;
            }
        }
        
        // Banned champion information
        public List<BannedChampion> BannedChampions
        {
            get
            {
                return this._bannedChampions;
            }
            set
            {
                this._bannedChampions = value;
            }
        }
        
        // The observer information
        public Observer Observers
        {
            get
            {
                return this._observers;
            }
            set
            {
                this._observers = value;
            }
        }
        
        // The participant information
        public List<Participant> Participants
        {
            get
            {
                return this._participants;
            }
            set
            {
                this._participants = value;
            }
        }
        
        // The amount of time in seconds that has passed since the game started
        public long GameLength
        {
            get
            {
                return this._gameLength;
            }
            set
            {
                this._gameLength = value;
            }
        }
        
        // The queue type (queue types are documented on the Game Constants page)
        public long GameQueueConfigId
        {
            get
            {
                return this._gameQueueConfigId;
            }
            set
            {
                this._gameQueueConfigId = value;
            }
        }
    }
}