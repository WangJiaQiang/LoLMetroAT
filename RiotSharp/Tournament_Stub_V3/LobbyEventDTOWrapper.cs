//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Tournament_Stub_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // 
    public class LobbyEventDTOWrapper
    {
        
        // 
        [JsonProperty("eventList")]
        private List<LobbyEventDTO> _eventList;
        
        // 
        public List<LobbyEventDTO> EventList
        {
            get
            {
                return this._eventList;
            }
            set
            {
                this._eventList = value;
            }
        }
    }
}
