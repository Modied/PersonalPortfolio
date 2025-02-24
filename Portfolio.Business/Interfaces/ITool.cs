using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface ITool
    {
        Task<ToolVModel> GetToolAsync(int Id);
        Task<IEnumerable<ToolVModel>> GetAllToolsAsync();
        Task AddToolAsync(ToolVModel toolVModel);
        Task UpdateToolAsync(ToolVModel toolVModel);
        Task<OprationStatusModel> DeleteToolAsync(int Id);
    }
}
