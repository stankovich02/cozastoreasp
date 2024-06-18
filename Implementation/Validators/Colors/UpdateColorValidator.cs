using Application.DTO.Categories;
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
    public class UpdateColorValidator : UpdateNamedEntityValidator<Color, UpdateColorDTO>
    {
        public UpdateColorValidator(CozaStoreContext context) : base(context, "Color")
        {
        }
    }
}
