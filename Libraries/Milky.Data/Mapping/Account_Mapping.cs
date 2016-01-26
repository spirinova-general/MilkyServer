using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Account_Mapping : EntityTypeConfiguration<Account>
    {
        public Account_Mapping()
        {
            this.ToTable("Account");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.DateAdded).IsRequired();
            this.Property(pr => pr.DateModified).IsRequired();
            this.Property(pr => pr.Dirty).IsRequired();
            this.Property(pr => pr.FarmerCode).IsRequired();
            this.Property(pr => pr.FirstName).IsRequired();
        }
    }
}