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
    public class FeaturedGames
    {
        
        // The suggested interval to wait before requesting  again
        [JsonProperty("clientRefreshInterval")]
        private long _clientRefreshInterval;
        
        // The list of featured games
        [JsonProperty("gameList")]
        private List<FeaturedGameInfo> _gameList;
        
        // The suggested interval to wait before requesting  again
        public long ClientRefreshInterval
        {
            get
            {
                return this._clientRefreshInterval;
            }
            set
            {
                this._clientRefreshInterval = value;
            }
        }
        
        // The list of featured games
        public List<FeaturedGameInfo> GameList
        {
            get
            {
                return this._gameList;
            }
            set
            {
                this._gameList = value;
            }
        }
    }
}
