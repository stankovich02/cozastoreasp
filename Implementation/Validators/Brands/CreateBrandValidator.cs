using Application.DTO.Brands;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Brands
{
    public class CreateBrandValidator : CreateNamedEntityValidator<Brand, CreateBrandDTO>
    {
        public CreateBrandValidator(CozaStoreContext context) : base(context, "Brand")
    {

    }
}
}
