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
    
    
    // 
    public class ParticipantDto
    {
        
        // 
        [JsonProperty("stats")]
        private ParticipantStatsDto _stats;
        
        // 
        [JsonProperty("participantId")]
        private int _participantId;
        
        // 
        [JsonProperty("runes")]
        private List<RuneDto> _runes;
        
        // 
        [JsonProperty("timeline")]
        private ParticipantTimelineDto _timeline;
        
        // 
        [JsonProperty("teamId")]
        private int _teamId;
        
        // 
        [JsonProperty("spell2Id")]
        private int _spell2Id;
        
        // 
        [JsonProperty("masteries")]
        private List<MasteryDto> _masteries;
        
        // 
        [JsonProperty("highestAchievedSeasonTier")]
        private string _highestAchievedSeasonTier;
        
        // 
        [JsonProperty("spell1Id")]
        private int _spell1Id;
        
        // 
        [JsonProperty("championId")]
        private int _championId;
        
        // 
        public ParticipantStatsDto Stats
        {
            get
            {
                return this._stats;
            }
            set
            {
                this._stats = value;
            }
        }
        
        // 
        public int ParticipantId
        {
            get
            {
                return this._participantId;
            }
            set
            {
                this._participantId = value;
            }
        }
        
        // 
        public List<RuneDto> Runes
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
        
        // 
        public ParticipantTimelineDto Timeline
        {
            get
            {
                return this._timeline;
            }
            set
            {
                this._timeline = value;
            }
        }
        
        // 
        public int TeamId
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
        
        // 
        public int Spell2Id
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
        
        // 
        public List<MasteryDto> Masteries
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
        
        // 
        public string HighestAchievedSeasonTier
        {
            get
            {
                return this._highestAchievedSeasonTier;
            }
            set
            {
                this._highestAchievedSeasonTier = value;
            }
        }
        
        // 
        public int Spell1Id
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
        
        // 
        public int ChampionId
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
    }
}
