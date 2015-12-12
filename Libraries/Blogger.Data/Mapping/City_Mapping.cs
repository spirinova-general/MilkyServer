using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class City_Mapping : EntityTypeConfiguration<City>
    {
        public City_Mapping()
        {
            this.ToTable("City");
            this.HasKey(pr => pr.Id);
            this.Property(pr => pr.Name).IsRequired();
        }
    }
}