using Application.DTO.Brands;
using Application.DTO.Colors;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Colors
{
    public class CreateColorValidator : CreateNamedEntityValidator<Color, CreateColorDTO>
    {
        public CreateColorValidator(CozaStoreContext context) : base(context, "Color")
        {

        }
    }
}