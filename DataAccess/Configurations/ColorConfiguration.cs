using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class ColorConfiguration : NamedEntityConfiguration<Color>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Color> builder)
        {
            
        }
    }
}
