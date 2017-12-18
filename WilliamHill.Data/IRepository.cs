using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace WilliamHill.Data
{
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
    }
}
