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
    
    
    // - This object contains champion passive data.
    public class PassiveDtoStatic
    {
        
        // 
        [JsonProperty("image")]
        private ImageDtoStatic _image;
        
        // 
        [JsonProperty("sanitizedDescription")]
        private string _sanitizedDescription;
        
        // 
        [JsonProperty("name")]
        private string _name;
        
        // 
        [JsonProperty("description")]
        private string _description;
        
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
        public string SanitizedDescription
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
        public string Description
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