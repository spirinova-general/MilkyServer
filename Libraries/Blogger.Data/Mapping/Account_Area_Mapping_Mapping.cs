using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Account_Area_Mapping_Mapping : EntityTypeConfiguration<Account_Area_Mapping>
    {
        public Account_Area_Mapping_Mapping()
        {
            this.ToTable("Account_Area_Mapping");
            this.HasKey(pr => pr.Id);
            this.HasRequired(o => o.Account)
                .WithMany()
                .HasForeignKey(o => o.AccountId)
                .WillCascadeOnDelete(false);
            this.HasRequired(o => o.Area)
               .WithMany()
               .HasForeignKey(o => o.AreaId)
               .WillCascadeOnDelete(false);
            this.Property(pr => pr.Dirty).IsRequired();
        }
    }
}