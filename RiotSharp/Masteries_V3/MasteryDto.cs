//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Masteries_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // - This object contains mastery information.
    public class MasteryDto
    {
        
        // Mastery ID. For static information correlating to masteries, please refer to the LoL Static Data API.
        [JsonProperty("id")]
        private int _id;
        
        // Mastery rank (i.e., the number of points put into this mastery).
        [JsonProperty("rank")]
        private int _rank;
        
        // Mastery ID. For static information correlating to masteries, please refer to the LoL Static Data API.
        public int Id
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
        
        // Mastery rank (i.e., the number of points put into this mastery).
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
