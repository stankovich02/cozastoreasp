using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Configurations
{
    public class PaymentTypeConfiguration : NamedEntityConfiguration<PaymentType>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<PaymentType> builder)
        {
            
        }
    }
}
