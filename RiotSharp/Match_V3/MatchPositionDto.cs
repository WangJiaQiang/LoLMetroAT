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
    public class MatchPositionDto
    {
        
        // 
        [JsonProperty("y")]
        private int _y;
        
        // 
        [JsonProperty("x")]
        private int _x;
        
        // 
        public int Y
        {
            get
            {
                return this._y;
            }
            set
            {
                this._y = value;
            }
        }
        
        // 
        public int X
        {
            get
            {
                return this._x;
            }
            set
            {
                this._x = value;
            }
        }
    }
}
