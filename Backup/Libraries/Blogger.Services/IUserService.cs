using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blogger.Services
{
   public interface IUserService
    {
        User GetById(int id);
        IList<User> GetByIds(int[] ids);
        //List<User> GetAllOperators(int accountId);
        User GetUser(string userName, string password);
        User GetUser(string userName);
        User Insert(User user);
        void Update(User user);
        void Delete(User user);
        //void InsertOperator(User user);
    }
}
