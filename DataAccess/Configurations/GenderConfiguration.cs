using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class GenderConfiguration : NamedEntityConfiguration<Gender>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Gender> builder)
        {
           
        }
    }
}
