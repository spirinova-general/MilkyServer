using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Bill_Mapping : EntityTypeConfiguration<Bill>
    {
        public Bill_Mapping()
        {
            this.ToTable("Bill");
            this.HasKey(pr => pr.Id);
            this.HasRequired(o => o.Account)
                .WithMany()
                .HasForeignKey(o => o.AccountId);
            this.HasRequired(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
            this.Property(pr => pr.Dirty).IsRequired();
            this.Property(pr => pr.Adjustment).IsRequired();
            this.Property(pr => pr.Balance).IsRequired();
            this.Property(pr => pr.DateAdded).IsRequired();
            this.Property(pr => pr.DateModified).IsRequired();
            this.Property(pr => pr.EndDate).IsRequired();
            this.Property(pr => pr.IsCleared).IsRequired();
            this.Property(pr => pr.PaymentMade).IsRequired();
            this.Property(pr => pr.Quantity).IsRequired();
            this.Property(pr => pr.StartDate).IsRequired();
            this.Property(pr => pr.Tax).IsRequired();
        }
    }

}