using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Customer_Mapping : EntityTypeConfiguration<Customer>
    {
        public Customer_Mapping()
        {
            this.ToTable("Customer");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.Address1).IsRequired();
            this.HasRequired(o => o.Account)
              .WithMany()
              .HasForeignKey(o => o.AccountId);
            this.HasRequired(o => o.Area)
                .WithMany()
                .HasForeignKey(o => o.AreaId);
            this.Property(pr => pr.Address2).IsRequired();
            this.Property(pr => pr.Balance).IsRequired();
            this.Property(pr => pr.DateAdded).IsRequired();
            this.Property(pr => pr.DateModified).IsRequired();
            this.Property(pr => pr.FirstName).IsRequired();
            this.Property(pr => pr.LastName).IsRequired();
            this.Property(pr => pr.Mobile).IsRequired();
        }
    }
}