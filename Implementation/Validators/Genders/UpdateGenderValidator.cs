using Application.DTO.Categories;
using Application.DTO.Genders;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Genders
{
    public class UpdateGenderValidator : UpdateNamedEntityValidator<Gender, UpdateGenderDTO>
    {
        public UpdateGenderValidator(CozaStoreContext context) : base(context, "Gender")
        {
        }
    }
}
