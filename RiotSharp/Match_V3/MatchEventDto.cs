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
    public class MatchEventDto
    {
        
        // 
        [JsonProperty("eventType")]
        private string _eventType;
        
        // 
        [JsonProperty("towerType")]
        private string _towerType;
        
        // 
        [JsonProperty("teamId")]
        private int _teamId;
        
        // 
        [JsonProperty("ascendedType")]
        private string _ascendedType;
        
        // 
        [JsonProperty("killerId")]
        private int _killerId;
        
        // 
        [JsonProperty("levelUpType")]
        private string _levelUpType;
        
        // 
        [JsonProperty("pointCaptured")]
        private string _pointCaptured;
        
        // 
        [JsonProperty("assistingParticipantIds")]
        private List<int> _assistingParticipantIds;
        
        // 
        [JsonProperty("wardType")]
        private string _wardType;
        
        // 
        [JsonProperty("monsterType")]
        private string _monsterType;
        
        // (Legal values:  CHAMPION_KILL,  WARD_PLACED,  WARD_KILL,  BUILDING_KILL,  ELITE_MONSTER_KILL,  ITEM_PURCHASED,  ITEM_SOLD,  ITEM_DESTROYED,  ITEM_UNDO,  SKILL_LEVEL_UP,  ASCENDED_EVENT,  CAPTURE_POINT,  PORO_KING_SUMMON)
        [JsonProperty("type")]
        private string _type;
        
        // 
        [JsonProperty("skillSlot")]
        private int _skillSlot;
        
        // 
        [JsonProperty("victimId")]
        private int _victimId;
        
        // 
        [JsonProperty("timestamp")]
        private long _timestamp;
        
        // 
        [JsonProperty("afterId")]
        private int _afterId;
        
        // 
        [JsonProperty("monsterSubType")]
        private string _monsterSubType;
        
        // 
        [JsonProperty("laneType")]
        private string _laneType;
        
        // 
        [JsonProperty("itemId")]
        private int _itemId;
        
        // 
        [JsonProperty("participantId")]
        private int _participantId;
        
        // 
        [JsonProperty("buildingType")]
        private string _buildingType;
        
        // 
        [JsonProperty("creatorId")]
        private int _creatorId;
        
        // 
        [JsonProperty("position")]
        private MatchPositionDto _position;
        
        // 
        [JsonProperty("beforeId")]
        private int _beforeId;
        
        // 
        public string EventType
        {
            get
            {
                return this._eventType;
            }
            set
            {
                this._eventType = value;
            }
        }
        
        // 
        public string TowerType
        {
            get
            {
                return this._towerType;
            }
            set
            {
                this._towerType = value;
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
        public string AscendedType
        {
            get
            {
                return this._ascendedType;
            }
            set
            {
                this._ascendedType = value;
            }
        }
        
        // 
        public int KillerId
        {
            get
            {
                return this._killerId;
            }
            set
            {
                this._killerId = value;
            }
        }
        
        // 
        public string LevelUpType
        {
            get
            {
                return this._levelUpType;
            }
            set
            {
                this._levelUpType = value;
            }
        }
        
        // 
        public string PointCaptured
        {
            get
            {
                return this._pointCaptured;
            }
            set
            {
                this._pointCaptured = value;
            }
        }
        
        // 
        public List<int> AssistingParticipantIds
        {
            get
            {
                return this._assistingParticipantIds;
            }
            set
            {
                this._assistingParticipantIds = value;
            }
        }
        
        // 
        public string WardType
        {
            get
            {
                return this._wardType;
            }
            set
            {
                this._wardType = value;
            }
        }
        
        // 
        public string MonsterType
        {
            get
            {
                return this._monsterType;
            }
            set
            {
                this._monsterType = value;
            }
        }
        
        // (Legal values:  CHAMPION_KILL,  WARD_PLACED,  WARD_KILL,  BUILDING_KILL,  ELITE_MONSTER_KILL,  ITEM_PURCHASED,  ITEM_SOLD,  ITEM_DESTROYED,  ITEM_UNDO,  SKILL_LEVEL_UP,  ASCENDED_EVENT,  CAPTURE_POINT,  PORO_KING_SUMMON)
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
        
        // 
        public int SkillSlot
        {
            get
            {
                return this._skillSlot;
            }
            set
            {
                this._skillSlot = value;
            }
        }
        
        // 
        public int VictimId
        {
            get
            {
                return this._victimId;
            }
            set
            {
                this._victimId = value;
            }
        }
        
        // 
        public long Timestamp
        {
            get
            {
                return this._timestamp;
            }
            set
            {
                this._timestamp = value;
            }
        }
        
        // 
        public int AfterId
        {
            get
            {
                return this._afterId;
            }
            set
            {
                this._afterId = value;
            }
        }
        
        // 
        public string MonsterSubType
        {
            get
            {
                return this._monsterSubType;
            }
            set
            {
                this._monsterSubType = value;
            }
        }
        
        // 
        public string LaneType
        {
            get
            {
                return this._laneType;
            }
            set
            {
                this._laneType = value;
            }
        }
        
        // 
        public int ItemId
        {
            get
            {
                return this._itemId;
            }
            set
            {
                this._itemId = value;
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
        public string BuildingType
        {
            get
            {
                return this._buildingType;
            }
            set
            {
                this._buildingType = value;
            }
        }
        
        // 
        public int CreatorId
        {
            get
            {
                return this._creatorId;
            }
            set
            {
                this._creatorId = value;
            }
        }
        
        // 
        public MatchPositionDto Position
        {
            get
            {
                return this._position;
            }
            set
            {
                this._position = value;
            }
        }
        
        // 
        public int BeforeId
        {
            get
            {
                return this._beforeId;
            }
            set
            {
                this._beforeId = value;
            }
        }
    }
}
