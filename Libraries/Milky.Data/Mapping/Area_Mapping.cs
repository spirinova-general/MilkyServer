using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class Area_Mapping : EntityTypeConfiguration<Area>
    {
        public Area_Mapping()
        {
            this.ToTable("Area");
            this.HasKey(pr => pr.Id);
            this.HasRequired(o => o.City)
               .WithMany()
               .HasForeignKey(o => o.CityId);
            this.Property(pr => pr.Name).IsRequired();
        }
    }
}