//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Lol_Status_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // 
    public class Incident
    {
        
        // 
        [JsonProperty("active")]
        private bool _active;
        
        // 
        [JsonProperty("created_at")]
        private string _created_at;
        
        // 
        [JsonProperty("id")]
        private long _id;
        
        // 
        [JsonProperty("updates")]
        private List<Message> _updates;
        
        // 
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
        
        // 
        public string Created_at
        {
            get
            {
                return this._created_at;
            }
            set
            {
                this._created_at = value;
            }
        }
        
        // 
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
        
        // 
        public List<Message> Updates
        {
            get
            {
                return this._updates;
            }
            set
            {
                this._updates = value;
            }
        }
    }
}