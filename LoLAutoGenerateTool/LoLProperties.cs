using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLAutoGenerateTool
{
    public class LoLProperties
    {
        string protyName = string.Empty;
        string protyType = string.Empty;
        string protyMemo = string.Empty;

        public string ProtyName
        { get { return protyName; } set { protyName = value; } }
        public string ProtyType
        { get { return protyType; } set { protyType = value; } }
        public string ProtyMemo
        { get { return protyMemo; } set { protyMemo = value; } }
    }
}
