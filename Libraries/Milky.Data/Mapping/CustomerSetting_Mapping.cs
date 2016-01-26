using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class CustomerSetting_Mapping : EntityTypeConfiguration<CustomerSetting>
    {
        public CustomerSetting_Mapping()
        {
            this.ToTable("CustomerSetting");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.DateModified).IsRequired();
            this.HasRequired(o => o.Account)
              .WithMany()
              .HasForeignKey(o => o.AccountId);
            this.HasRequired(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            this.Property(pr => pr.DefaultQuantity).IsRequired();
            this.Property(pr => pr.Rate).IsRequired();
        }
    }
}