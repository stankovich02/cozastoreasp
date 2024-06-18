using Application.DTO.Brands;
using Application.DTO.Categories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Brands
{
    public class UpdateBrandValidator : UpdateNamedEntityValidator<Brand, UpdateBrandDTO>
    {
        public UpdateBrandValidator(CozaStoreContext context) : base(context, "Brand")
        {
        }
    }
}
