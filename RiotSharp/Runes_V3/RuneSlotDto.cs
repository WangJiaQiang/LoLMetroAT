//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Runes_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // - This object contains rune slot information.
    public class RuneSlotDto
    {
        
        // Rune slot ID.
        [JsonProperty("runeSlotId")]
        private int _runeSlotId;
        
        // Rune ID associated with the rune slot. For static information correlating to rune IDs, please refer to the LoL Static Data API.
        [JsonProperty("runeId")]
        private int _runeId;
        
        // Rune slot ID.
        public int RuneSlotId
        {
            get
            {
                return this._runeSlotId;
            }
            set
            {
                this._runeSlotId = value;
            }
        }
        
        // Rune ID associated with the rune slot. For static information correlating to rune IDs, please refer to the LoL Static Data API.
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
    }
}
