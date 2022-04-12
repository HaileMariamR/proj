using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Models;

namespace DesktopApp.IRepositories
{
    public interface ICrudService<T>
    {
        Task<bool> Add(T item);
        Task<bool> Update(T item , int id);
        Task<List<User>> GetAll();
        Task<bool> Remove(int id);
    }
}
