using Microsoft.AspNetCore.Http;
using Portfolio.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IPersonalInfo
    {
        Task<IEnumerable<PersonalInfoVModel>> GetPersonalInfoAsync();
        Task<PersonalInfoVModel> GetPersonalInfoByIDAsync(int id);
        Task<PersonalInfoVModel> GetFirstPersonalInfoAsync();
        Task<PersonalInfo> AddPersonalInfoAsync(PersonalInfoVModel personalInfoVModel);
        Task<PersonalInfo> UpdatePersonalInfoAsync(PersonalInfoVModel newPersonalInfoVModel);
        Task<OprationStatusModel> DeletePersonalInfoAsync(int id);



    }
}
