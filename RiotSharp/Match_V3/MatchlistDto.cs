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
    public class MatchlistDto
    {
        
        // 
        [JsonProperty("matches")]
        private List<MatchReferenceDto> _matches;
        
        // 
        [JsonProperty("totalGames")]
        private int _totalGames;
        
        // 
        [JsonProperty("startIndex")]
        private int _startIndex;
        
        // 
        [JsonProperty("endIndex")]
        private int _endIndex;
        
        // 
        public List<MatchReferenceDto> Matches
        {
            get
            {
                return this._matches;
            }
            set
            {
                this._matches = value;
            }
        }
        
        // 
        public int TotalGames
        {
            get
            {
                return this._totalGames;
            }
            set
            {
                this._totalGames = value;
            }
        }
        
        // 
        public int StartIndex
        {
            get
            {
                return this._startIndex;
            }
            set
            {
                this._startIndex = value;
            }
        }
        
        // 
        public int EndIndex
        {
            get
            {
                return this._endIndex;
            }
            set
            {
                this._endIndex = value;
            }
        }
    }
}
