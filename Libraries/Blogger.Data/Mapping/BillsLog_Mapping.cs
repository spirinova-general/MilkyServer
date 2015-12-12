using Blogger.Core.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace Blogger.Data.Mapping
{
    public class BillsLog_Mapping : EntityTypeConfiguration<BillsLog>
    {
        public BillsLog_Mapping()
        {
            this.ToTable("BillsLog");
            this.HasKey(pr => pr.Id);
        }
    }
}