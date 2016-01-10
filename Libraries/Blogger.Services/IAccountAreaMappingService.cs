using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogger.Services
{
    public interface IAccountAreaMappingService
    {
        Account_Area_Mapping GetById(int id);
        Account_Area_Mapping GetByClientIdAccountId(int clientId, int accountId);
        void Insert(Account_Area_Mapping accountArea);
        void Update(Account_Area_Mapping accountArea);
        void Delete(Account_Area_Mapping accountArea);
        List<Account_Area_Mapping> GetAll();
    }
}