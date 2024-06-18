using Application.DTO.Categories;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Categories
{
    public class UpdateCategoryValidator : UpdateNamedEntityValidator<Category, UpdateCategoryDTO>
    {
        public UpdateCategoryValidator(CozaStoreContext context) : base(context, "Category")
        {
        }
    }
}
