//------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン:4.0.30319.42000
//
//     このファイルへの変更は、以下の状況下で不正な動作の原因になったり、
//     コードが再生成されるときに損失したりします。
// </auto-generated>
//------------------------------------------------------------------------------

namespace RiotSharp.Lol_Static_Data_V3
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Collections;
    using Newtonsoft.Json;
    
    
    // - This object contains spell vars data.
    public class SpellVarsDtoStatic
    {
        
        // 
        [JsonProperty("ranksWith")]
        private string _ranksWith;
        
        // 
        [JsonProperty("dyn")]
        private string _dyn;
        
        // 
        [JsonProperty("link")]
        private string _link;
        
        // 
        [JsonProperty("coeff")]
        private List<double> _coeff;
        
        // 
        [JsonProperty("key")]
        private string _key;
        
        // 
        public string RanksWith
        {
            get
            {
                return this._ranksWith;
            }
            set
            {
                this._ranksWith = value;
            }
        }
        
        // 
        public string Dyn
        {
            get
            {
                return this._dyn;
            }
            set
            {
                this._dyn = value;
            }
        }
        
        // 
        public string Link
        {
            get
            {
                return this._link;
            }
            set
            {
                this._link = value;
            }
        }
        
        // 
        public List<double> Coeff
        {
            get
            {
                return this._coeff;
            }
            set
            {
                this._coeff = value;
            }
        }
        
        // 
        public string Key
        {
            get
            {
                return this._key;
            }
            set
            {
                this._key = value;
            }
        }
    }
}
