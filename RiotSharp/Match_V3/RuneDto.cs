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
    public class RuneDto
    {
        
        // 
        [JsonProperty("runeId")]
        private int _runeId;
        
        // 
        [JsonProperty("rank")]
        private int _rank;
        
        // 
        public int RuneId
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
        
        // 
        public int Rank
        {
            get
            {
                return this._rank;
            }
            set
            {
                this._rank = value;
            }
        }
    }
}