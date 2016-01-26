using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Delivery_Mapping : EntityTypeConfiguration<Delivery>
    {
        public Delivery_Mapping()
        {
            this.ToTable("Delivery");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.Quantity).IsRequired();
            this.HasRequired(o => o.Account)
              .WithMany()
              .HasForeignKey(o => o.AccountId);
            this.HasRequired(o => o.Customer)
                .WithMany()
                .HasForeignKey(o => o.CustomerId);
        }
    }
}