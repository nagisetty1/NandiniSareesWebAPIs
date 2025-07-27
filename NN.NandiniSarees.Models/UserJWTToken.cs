using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Models
{
    public class UserJWTToken
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? EmailId { get; set; }
        public Guid? JWTToken { get; set; }
    }
}
