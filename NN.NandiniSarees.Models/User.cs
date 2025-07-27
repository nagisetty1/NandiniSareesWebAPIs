using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NN.NandiniSarees.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? PasswordHash { get; set; } // Null for external logins
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        public DateTime LastLoggedInAt { get; set; } = DateTime.UtcNow;

        // External login support
        public string? AuthProvider { get; set; } // "Google", "LinkedIn", "Microsoft", or null for local
        public string? ProviderUserId { get; set; } // Unique ID from provider
    }
}
