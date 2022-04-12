using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesktopApp.Models;
using DesktopApp.IRepositories;


namespace DesktopApp.IRepositories
{
    public interface IUserService : ICrudService<User>
    {
    }
}
