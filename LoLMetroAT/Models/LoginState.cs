using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoLMetroAT.Models
{
    public class LoginState
    {
        public bool LoginErrorFlg { get; set; }

        public bool LoginTypeFlg { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}
