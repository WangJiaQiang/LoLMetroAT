//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Champion_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // - This object contains champion information.
    public class ChampionDto
    {
        
        // Ranked play enabled flag.
        [JsonProperty("rankedPlayEnabled")]
        private bool _rankedPlayEnabled;
        
        // Bot enabled flag (for custom games).
        [JsonProperty("botEnabled")]
        private bool _botEnabled;
        
        // Bot Match Made enabled flag (for Co-op vs. AI games).
        [JsonProperty("botMmEnabled")]
        private bool _botMmEnabled;
        
        // Indicates if the champion is active.
        [JsonProperty("active")]
        private bool _active;
        
        // Indicates if the champion is free to play. Free to play champions are rotated periodically.
        [JsonProperty("freeToPlay")]
        private bool _freeToPlay;
        
        // Champion ID. For static information correlating to champion IDs, please refer to the LoL Static Data API.
        [JsonProperty("id")]
        private long _id;
        
        // Ranked play enabled flag.
        public bool RankedPlayEnabled
        {
            get
            {
                return this._rankedPlayEnabled;
            }
            set
            {
                this._rankedPlayEnabled = value;
            }
        }
        
        // Bot enabled flag (for custom games).
        public bool BotEnabled
        {
            get
            {
                return this._botEnabled;
            }
            set
            {
                this._botEnabled = value;
            }
        }
        
        // Bot Match Made enabled flag (for Co-op vs. AI games).
        public bool BotMmEnabled
        {
            get
            {
                return this._botMmEnabled;
            }
            set
            {
                this._botMmEnabled = value;
            }
        }
        
        // Indicates if the champion is active.
        public bool Active
        {
            get
            {
                return this._active;
            }
            set
            {
                this._active = value;
            }
        }
        
        // Indicates if the champion is free to play. Free to play champions are rotated periodically.
        public bool FreeToPlay
        {
            get
            {
                return this._freeToPlay;
            }
            set
            {
                this._freeToPlay = value;
            }
        }
        
        // Champion ID. For static information correlating to champion IDs, please refer to the LoL Static Data API.
        public long Id
        {
            get
            {
                return this._id;
            }
            set
            {
                this._id = value;
            }
        }
    }
}
