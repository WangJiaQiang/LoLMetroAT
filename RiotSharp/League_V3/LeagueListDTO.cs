//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.League_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // 
    public class LeagueListDTO
    {
        
        // 
        [JsonProperty("tier")]
        private string _tier;
        
        // 
        [JsonProperty("queue")]
        private string _queue;
        
        // 
        [JsonProperty("name")]
        private string _name;
        
        // 
        [JsonProperty("entries")]
        private List<LeagueItemDTO> _entries;
        
        // 
        public string Tier
        {
            get
            {
                return this._tier;
            }
            set
            {
                this._tier = value;
            }
        }
        
        // 
        public string Queue
        {
            get
            {
                return this._queue;
            }
            set
            {
                this._queue = value;
            }
        }
        
        // 
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        
        // 
        public List<LeagueItemDTO> Entries
        {
            get
            {
                return this._entries;
            }
            set
            {
                this._entries = value;
            }
        }
    }
}
