using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {


        /* Start of =>  Get Abstract Function */

        Task<T> GetByIDAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetFirstAsync();
        Task<IEnumerable<T>> GetAllIncludesAsync(string[] includes);


        /* End of =>  Get Abstract Function */

        /***********************************************/

        /* Start of => Find Abstract Function */
        Task<T> FindByExpAsync(Expression<Func<T, bool>> bResult);

        Task<IEnumerable<T>> FindByExpIncludeAsync(Expression<Func<T, bool>> bResult, string[] includes);

        /* End of   =>  Find Abstract Function */

        /***********************************************/

        /* Start of =>  Add Abstract Function */

        Task<T> AddAsync(T entity);

        Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities);

        /* End of   =>  Add Abstract Function */

        /***********************************************/

        /* Start of =>  Update Abstract Function */
        Task<T> UpdateAsync(T entity, Expression<Func<T, bool>> criteria);
        Task<IEnumerable<T>> UpdateRangeAsync(IEnumerable<T> entity, Expression<Func<T, bool>> criteria);
        /* End of   =>  Update Abstract Function */

        /***********************************************/

        /* Start of =>  Delete Abstract Function */
        Task<T> DeleteAsync(T entity);
        Task<T> DeleteByIdAsync(int id);
        /* End of   =>  Delete Abstract Function */

        /***********************************************/



    }
}
