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
    public class Translation
    {
        
        // 
        [JsonProperty("locale")]
        private string _locale;
        
        // 
        [JsonProperty("content")]
        private string _content;
        
        // 
        [JsonProperty("updated_at")]
        private string _updated_at;
        
        // 
        public string Locale
        {
            get
            {
                return this._locale;
            }
            set
            {
                this._locale = value;
            }
        }
        
        // 
        public string Content
        {
            get
            {
                return this._content;
            }
            set
            {
                this._content = value;
            }
        }
        
        // 
        public string Updated_at
        {
            get
            {
                return this._updated_at;
            }
            set
            {
                this._updated_at = value;
            }
        }
    }
}
