using Application.DTO.Colors;
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
    public class CreateGenderValidator : CreateNamedEntityValidator<Gender, CreateGenderDTO>
    {
        public CreateGenderValidator(CozaStoreContext context) : base(context, "Gender")
        {

        }
    }
}
