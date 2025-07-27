using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Models
{
    public class LoginUser
    {
        public string UsernameOrEmail { get; set; } = string.Empty;
        public string? Password { get; set; }
    }
}
