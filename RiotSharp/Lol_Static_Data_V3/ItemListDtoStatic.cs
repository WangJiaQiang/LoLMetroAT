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
    
    
    // - This object contains item list data.
    public class ItemListDtoStatic
    {
        
        // 
        [JsonProperty("data")]
        private System.Collections.Generic.Dictionary<string, ItemDtoStatic> _data;
        
        // 
        [JsonProperty("version")]
        private string _version;
        
        // 
        [JsonProperty("tree")]
        private List<ItemTreeDtoStatic> _tree;
        
        // 
        [JsonProperty("groups")]
        private List<GroupDtoStatic> _groups;
        
        // 
        [JsonProperty("type")]
        private string _type;
        
        // 
        public System.Collections.Generic.Dictionary<string, ItemDtoStatic> Data
        {
            get
            {
                return this._data;
            }
            set
            {
                this._data = value;
            }
        }
        
        // 
        public string Version
        {
            get
            {
                return this._version;
            }
            set
            {
                this._version = value;
            }
        }
        
        // 
        public List<ItemTreeDtoStatic> Tree
        {
            get
            {
                return this._tree;
            }
            set
            {
                this._tree = value;
            }
        }
        
        // 
        public List<GroupDtoStatic> Groups
        {
            get
            {
                return this._groups;
            }
            set
            {
                this._groups = value;
            }
        }
        
        // 
        public string Type
        {
            get
            {
                return this._type;
            }
            set
            {
                this._type = value;
            }
        }
    }
}
