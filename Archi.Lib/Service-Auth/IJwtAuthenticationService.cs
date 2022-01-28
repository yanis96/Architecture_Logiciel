using Archi.Library.Models;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace Archi.Library.Service_auth

{
    public interface IJwtAuthenticationService
    {
        User Authenticate(string email, string password);
        string GenerateToken(string secret, List<Claim> claims);
    }
}

