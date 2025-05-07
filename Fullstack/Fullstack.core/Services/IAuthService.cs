using Fullstack.Core.Models.DTOs.Fullstack.Core.Models.DTOs;
using Fullstack.Core.Models.DTOs;
using Fullstack.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fullstack.Core.Services
{
    public interface IAuthService
    {
        Task<User> RegisterAsync(RegisterDTO model);
        Task<string> LoginAsync(LoginDTO model);
    }
}
