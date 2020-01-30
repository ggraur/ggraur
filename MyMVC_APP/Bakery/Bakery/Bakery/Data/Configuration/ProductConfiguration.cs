using Bakery.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Data.Configuration
{
    public class ProductConfiguration
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.ImageName).HasColumnName("ImageFileName");
        }
    }
}
