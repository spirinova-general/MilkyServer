using AutoMapper;
using Blogger.Core.Domain;
using Contacts.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Contacts.Web.Extensions
{
    public static class MappingExtensions
    {
        #region Account

        public static AccountModel ToModel(this Account entity)
        {
            Mapper.CreateMap<Account, AccountModel>();
            return Mapper.Map<Account, AccountModel>(entity);
        }

        public static Account ToEntity(this AccountModel model)
        {
            Mapper.CreateMap<AccountModel, Account>();
            return Mapper.Map<AccountModel, Account>(model);
        }

        public static Account ToEntity(this AccountModel model, Account destination)
        {
            return Mapper.Map(model, destination);
        }

        #endregion
  
       
    }
}