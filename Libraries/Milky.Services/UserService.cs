using Blogger.Core.Domain;
using Blogger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public class UserService : IUserService
    {

        #region Field
        private IRepository<User> _userRepository;
        #endregion

        #region Ctor
        public UserService(IRepository<User> userRepository
            )
        {
            this._userRepository = userRepository;
        }
        #endregion

        #region
        public User GetById(int id)
        {
            var query = (from c in _userRepository.Table
                         where c.Id == id
                         select c).FirstOrDefault();
            return query;
        }
        public IList<User> GetByIds(int[] ids)
        {
            if (ids == null || ids.Length == 0)
                return new List<User>();

            var query = from p in _userRepository.Table
                        where ids.Contains(p.Id)
                        select p;
            var users = query.ToList();
            //sort by passed identifiers
            var sorteduser = new List<User>();
            foreach (int id in ids)
            {
                var user = users.Find(x => x.Id == id);
                if (user != null)
                    sorteduser.Add(user);
            }
            return sorteduser;
        }
        public User GetUser(string userName, string password)
        {
            var query = (from c in _userRepository.Table
                         where c.Username == userName && c.Password == password
                         select c).FirstOrDefault();
            return query;
        }
        public User GetUser(string userName)
        {
            var query = (from c in _userRepository.Table
                         where c.Username == userName
                         select c).FirstOrDefault();
            return query;
        }
        public User Insert(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            _userRepository.Insert(user);
            return user;
        }
        public void Update(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            _userRepository.Update(user);
        }
        public void Delete(User user)
        {
            if (user == null)
                throw new ArgumentNullException("User");
            _userRepository.Delete(user);

        }
        public List<User> GetAllOperators(int accountId)
        {
            var query = (from c in _userRepository.Table
                         //where c.Role == SystemUserRoleNames.Operators
                         //&& c.AccountId == accountId
                         orderby c.Id
                         select c);
            return query.ToList();
        }

        //public void InsertOperator(User user)
        //{
        //    user.Role =  SystemUserRoleNames.Operators;
        //    user.Username +=  //append admin name 
        //    Insert(user);
        //}
    }
        #endregion
}