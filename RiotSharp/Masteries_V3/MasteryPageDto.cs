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
    
    
    // - This object contains mastery page information.
    public class MasteryPageDto
    {
        
        // Indicates if the mastery page is the current mastery page.
        [JsonProperty("current")]
        private bool _current;
        
        // Collection of masteries associated with the mastery page.
        [JsonProperty("masteries")]
        private List<MasteryDto> _masteries;
        
        // Mastery page name.
        [JsonProperty("name")]
        private string _name;
        
        // Mastery page ID.
        [JsonProperty("id")]
        private long _id;
        
        // Indicates if the mastery page is the current mastery page.
        public bool Current
        {
            get
            {
                return this._current;
            }
            set
            {
                this._current = value;
            }
        }
        
        // Collection of masteries associated with the mastery page.
        public List<MasteryDto> Masteries
        {
            get
            {
                return this._masteries;
            }
            set
            {
                this._masteries = value;
            }
        }
        
        // Mastery page name.
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }
        
        // Mastery page ID.
        public long Id
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
    }
}
