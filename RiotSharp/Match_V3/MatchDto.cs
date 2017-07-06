//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Match_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    using RiotSharp.Misc.Converters;
    
    
    // 
    public class MatchDto
    {
        
        // 
        [JsonProperty("seasonId")]
        private int _seasonId;
        
        // 
        [JsonProperty("queueId")]
        private int _queueId;
        
        // 
        [JsonProperty("gameId")]
        private long _gameId;
        
        // 
        [JsonProperty("participantIdentities")]
        private List<ParticipantIdentityDto> _participantIdentities;
        
        // 
        [JsonProperty("gameVersion")]
        private string _gameVersion;
        
        // 
        [JsonProperty("platformId")]
        private string _platformId;
        
        // 
        [JsonProperty("gameMode")]
        private string _gameMode;
        
        // 
        [JsonProperty("mapId")]
        private int _mapId;
        
        // 
        [JsonProperty("gameType")]
        private string _gameType;
        
        // 
        [JsonProperty("teams")]
        private List<TeamStatsDto> _teams;
        
        // 
        [JsonProperty("participants")]
        private List<ParticipantDto> _participants;
        
        // 
        [JsonProperty("gameDuration")]
        private long _gameDuration;
        
        // 
        [JsonProperty("gameCreation")]
        [JsonConverter(typeof(DateTimeConverterFromLong))]
        private DateTime _gameCreation;
        
        // 
        public int SeasonId
        {
            get
            {
                return this._seasonId;
            }
            set
            {
                this._seasonId = value;
            }
        }
        
        // 
        public int QueueId
        {
            get
            {
                return this._queueId;
            }
            set
            {
                this._queueId = value;
            }
        }
        
        // 
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
        
        // 
        public List<ParticipantIdentityDto> ParticipantIdentities
        {
            get
            {
                return this._participantIdentities;
            }
            set
            {
                this._participantIdentities = value;
            }
        }
        
        // 
        public string GameVersion
        {
            get
            {
                return this._gameVersion;
            }
            set
            {
                this._gameVersion = value;
            }
        }
        
        // 
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
        
        // 
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
        
        // 
        public int MapId
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
        
        // 
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
        
        // 
        public List<TeamStatsDto> Teams
        {
            get
            {
                return this._teams;
            }
            set
            {
                this._teams = value;
            }
        }
        
        // 
        public List<ParticipantDto> Participants
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
        
        // 
        public long GameDuration
        {
            get
            {
                return this._gameDuration;
            }
            set
            {
                this._gameDuration = value;
            }
        }
        
        // 
        public DateTime GameCreation
        {
            get
            {
                return this._gameCreation;
            }
            set
            {
                this._gameCreation = value;
            }
        }
    }
}
