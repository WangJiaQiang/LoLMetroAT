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
    
    
    // - This object contains map details data.
    public class MapDetailsDtoStatic
    {
        
        // 
        [JsonProperty("mapName")]
        private string _mapName;
        
        // 
        [JsonProperty("image")]
        private ImageDtoStatic _image;
        
        // 
        [JsonProperty("mapId")]
        private long _mapId;
        
        // 
        [JsonProperty("unpurchasableItemList")]
        private List<long> _unpurchasableItemList;
        
        // 
        public string MapName
        {
            get
            {
                return this._mapName;
            }
            set
            {
                this._mapName = value;
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
        public long MapId
        {
            get
            {
                return this._mapId;
            }
            set
            {
                this._mapId = value;
            }
        }
        
        // 
        public List<long> UnpurchasableItemList
        {
            get
            {
                return this._unpurchasableItemList;
            }
            set
            {
                this._unpurchasableItemList = value;
            }
        }
    }
}
