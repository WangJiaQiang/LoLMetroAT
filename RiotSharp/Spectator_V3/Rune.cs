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
    public class Rune
    {
        
        // The count of this rune used by the participant
        [JsonProperty("count")]
        private int _count;
        
        // The ID of the rune
        [JsonProperty("runeId")]
        private long _runeId;
        
        // The count of this rune used by the participant
        public int Count
        {
            get
            {
                return this._count;
            }
            set
            {
                this._count = value;
            }
        }
        
        // The ID of the rune
        public long RuneId
        {
            get
            {
                return this._runeId;
            }
            set
            {
                this._runeId = value;
            }
        }
    }
}
