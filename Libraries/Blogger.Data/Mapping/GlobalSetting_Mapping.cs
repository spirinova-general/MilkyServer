using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class GlobalSetting_Mapping : EntityTypeConfiguration<GlobalSetting>
    {
        public GlobalSetting_Mapping()
        {
            this.ToTable("GlobalSetting");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.DateModified).IsRequired();
            this.Property(pr => pr.DefaultRate).IsRequired();
            this.HasRequired(o => o.Account)
              .WithMany()
              .HasForeignKey(o => o.AccountId);
        }
    }
}