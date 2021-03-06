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
    
    
    // - This object contains realm data.
    public class RealmDtoStatic
    {
        
        // Legacy script mode for IE6 or older.
        [JsonProperty("lg")]
        private string _lg;
        
        // Latest changed version of Dragon Magic.
        [JsonProperty("dd")]
        private string _dd;
        
        // Default language for this realm.
        [JsonProperty("l")]
        private string _l;
        
        // Latest changed version for each data type listed.
        [JsonProperty("n")]
        private System.Collections.Generic.Dictionary<string, string> _n;
        
        // Special behavior number identifying the largest profile icon ID that can be used under 500. Any profile icon that is requested between this number and 500 should be mapped to 0.
        [JsonProperty("profileiconmax")]
        private int _profileiconmax;
        
        // Additional API data drawn from other sources that may be related to Data Dragon functionality.
        [JsonProperty("store")]
        private string _store;
        
        // Current version of this file for this realm.
        [JsonProperty("v")]
        private string _v;
        
        // The base CDN URL.
        [JsonProperty("cdn")]
        private string _cdn;
        
        // Latest changed version of Dragon Magic's CSS file.
        [JsonProperty("css")]
        private string _css;
        
        // Legacy script mode for IE6 or older.
        public string Lg
        {
            get
            {
                return this._lg;
            }
            set
            {
                this._lg = value;
            }
        }
        
        // Latest changed version of Dragon Magic.
        public string Dd
        {
            get
            {
                return this._dd;
            }
            set
            {
                this._dd = value;
            }
        }
        
        // Default language for this realm.
        public string L
        {
            get
            {
                return this._l;
            }
            set
            {
                this._l = value;
            }
        }
        
        // Latest changed version for each data type listed.
        public System.Collections.Generic.Dictionary<string, string> N
        {
            get
            {
                return this._n;
            }
            set
            {
                this._n = value;
            }
        }
        
        // Special behavior number identifying the largest profile icon ID that can be used under 500. Any profile icon that is requested between this number and 500 should be mapped to 0.
        public int Profileiconmax
        {
            get
            {
                return this._profileiconmax;
            }
            set
            {
                this._profileiconmax = value;
            }
        }
        
        // Additional API data drawn from other sources that may be related to Data Dragon functionality.
        public string Store
        {
            get
            {
                return this._store;
            }
            set
            {
                this._store = value;
            }
        }
        
        // Current version of this file for this realm.
        public string V
        {
            get
            {
                return this._v;
            }
            set
            {
                this._v = value;
            }
        }
        
        // The base CDN URL.
        public string Cdn
        {
            get
            {
                return this._cdn;
            }
            set
            {
                this._cdn = value;
            }
        }
        
        // Latest changed version of Dragon Magic's CSS file.
        public string Css
        {
            get
            {
                return this._css;
            }
            set
            {
                this._css = value;
            }
        }
    }
}
