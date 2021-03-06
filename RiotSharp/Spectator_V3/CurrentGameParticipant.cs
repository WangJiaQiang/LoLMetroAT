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
    public class CurrentGameParticipant
    {
        
        // The ID of the profile icon used by this participant
        [JsonProperty("profileIconId")]
        private long _profileIconId;
        
        // The ID of the champion played by this participant
        [JsonProperty("championId")]
        private long _championId;
        
        // The summoner name of this participant
        [JsonProperty("summonerName")]
        private string _summonerName;
        
        // The runes used by this participant
        [JsonProperty("runes")]
        private List<Rune> _runes;
        
        // Flag indicating whether or not this participant is a bot
        [JsonProperty("bot")]
        private bool _bot;
        
        // The team ID of this participant, indicating the participant's team
        [JsonProperty("teamId")]
        private long _teamId;
        
        // The ID of the second summoner spell used by this participant
        [JsonProperty("spell2Id")]
        private long _spell2Id;
        
        // The masteries used by this participant
        [JsonProperty("masteries")]
        private List<Mastery> _masteries;
        
        // The ID of the first summoner spell used by this participant
        [JsonProperty("spell1Id")]
        private long _spell1Id;
        
        // The summoner ID of this participant
        [JsonProperty("summonerId")]
        private long _summonerId;
        
        // The ID of the profile icon used by this participant
        public long ProfileIconId
        {
            get
            {
                return this._profileIconId;
            }
            set
            {
                this._profileIconId = value;
            }
        }
        
        // The ID of the champion played by this participant
        public long ChampionId
        {
            get
            {
                return this._championId;
            }
            set
            {
                this._championId = value;
            }
        }
        
        // The summoner name of this participant
        public string SummonerName
        {
            get
            {
                return this._summonerName;
            }
            set
            {
                this._summonerName = value;
            }
        }
        
        // The runes used by this participant
        public List<Rune> Runes
        {
            get
            {
                return this._runes;
            }
            set
            {
                this._runes = value;
            }
        }
        
        // Flag indicating whether or not this participant is a bot
        public bool Bot
        {
            get
            {
                return this._bot;
            }
            set
            {
                this._bot = value;
            }
        }
        
        // The team ID of this participant, indicating the participant's team
        public long TeamId
        {
            get
            {
                return this._teamId;
            }
            set
            {
                this._teamId = value;
            }
        }
        
        // The ID of the second summoner spell used by this participant
        public long Spell2Id
        {
            get
            {
                return this._spell2Id;
            }
            set
            {
                this._spell2Id = value;
            }
        }
        
        // The masteries used by this participant
        public List<Mastery> Masteries
        {
            get
            {
                return this._masteries;
            }
            set
            {
                this._masteries = value;
            }
        }
        
        // The ID of the first summoner spell used by this participant
        public long Spell1Id
        {
            get
            {
                return this._spell1Id;
            }
            set
            {
                this._spell1Id = value;
            }
        }
        
        // The summoner ID of this participant
        public long SummonerId
        {
            get
            {
                return this._summonerId;
            }
            set
            {
                this._summonerId = value;
            }
        }
    }
}
