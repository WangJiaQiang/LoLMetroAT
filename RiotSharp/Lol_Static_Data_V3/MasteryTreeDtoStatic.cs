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
    
    
    // - This object contains mastery tree data.
    public class MasteryTreeDtoStatic
    {
        
        // 
        [JsonProperty("Resolve")]
        private List<MasteryTreeListDtoStatic> _resolve;
        
        // 
        [JsonProperty("Ferocity")]
        private List<MasteryTreeListDtoStatic> _ferocity;
        
        // 
        [JsonProperty("Cunning")]
        private List<MasteryTreeListDtoStatic> _cunning;
        
        // 
        public List<MasteryTreeListDtoStatic> ReName_Resolve
        {
            get
            {
                return this._resolve;
            }
            set
            {
                this._resolve = value;
            }
        }
        
        // 
        public List<MasteryTreeListDtoStatic> ReName_Ferocity
        {
            get
            {
                return this._ferocity;
            }
            set
            {
                this._ferocity = value;
            }
        }
        
        // 
        public List<MasteryTreeListDtoStatic> ReName_Cunning
        {
            get
            {
                return this._cunning;
            }
            set
            {
                this._cunning = value;
            }
        }
    }
}
