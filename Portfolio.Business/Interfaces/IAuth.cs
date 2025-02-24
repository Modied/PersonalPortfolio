using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IAuth
    {

        Task<AuthVModel> LoginAsync(LoginVModel loginVModel);
        Task<AuthVModel> RegisterAsync(RegisterVModel registerVModel);
        Task<LoginVModel> InitialAdminAsync();



    }
}
