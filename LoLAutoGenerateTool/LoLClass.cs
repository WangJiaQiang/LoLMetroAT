using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLAutoGenerateTool
{
    public class LoLClass
    {
        string className = string.Empty;
        string classMemo = string.Empty;

        public string ClassName
        { get { return className; } set { className = value; } }
        public string ClassMemo
        { get { return classMemo; } set { classMemo = value; } }
    }
}
