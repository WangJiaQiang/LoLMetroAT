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
    public class MatchTimelineDto
    {
        
        // 
        [JsonProperty("frames")]
        private List<MatchFrameDto> _frames;
        
        // 
        [JsonProperty("frameInterval")]
        private long _frameInterval;
        
        // 
        public List<MatchFrameDto> Frames
        {
            get
            {
                return this._frames;
            }
            set
            {
                this._frames = value;
            }
        }
        
        // 
        public long FrameInterval
        {
            get
            {
                return this._frameInterval;
            }
            set
            {
                this._frameInterval = value;
            }
        }
    }
}
