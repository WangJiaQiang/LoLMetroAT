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
    
    
    // - This object contains mastery data.
    public class MasteryDtoStatic
    {
        
        // 
        [JsonProperty("prereq")]
        private string _prereq;
        
        // (Legal values:  Cunning,  Ferocity,  Resolve)
        [JsonProperty("masteryTree")]
        private string _masteryTree;
        
        // 
        [JsonProperty("name")]
        private string _name;
        
        // 
        [JsonProperty("ranks")]
        private int _ranks;
        
        // 
        [JsonProperty("image")]
        private ImageDtoStatic _image;
        
        // 
        [JsonProperty("sanitizedDescription")]
        private List<string> _sanitizedDescription;
        
        // 
        [JsonProperty("id")]
        private int _id;
        
        // 
        [JsonProperty("description")]
        private List<string> _description;
        
        // 
        public string Prereq
        {
            get
            {
                return this._prereq;
            }
            set
            {
                this._prereq = value;
            }
        }
        
        // (Legal values:  Cunning,  Ferocity,  Resolve)
        public string MasteryTree
        {
            get
            {
                return this._masteryTree;
            }
            set
            {
                this._masteryTree = value;
            }
        }
        
        // 
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
        
        // 
        public int Ranks
        {
            get
            {
                return this._ranks;
            }
            set
            {
                this._ranks = value;
            }
        }
        
        // 
        public ImageDtoStatic Image
        {
            get
            {
                return this._image;
            }
            set
            {
                this._image = value;
            }
        }
        
        // 
        public List<string> SanitizedDescription
        {
            get
            {
                return this._sanitizedDescription;
            }
            set
            {
                this._sanitizedDescription = value;
            }
        }
        
        // 
        public int Id
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
        
        // 
        public List<string> Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }
    }
}
