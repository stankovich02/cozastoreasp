using Application.DTO.Categories;
using DataAccess;
using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.Validators.Categories
{
    public class CreateCategoryValidator : CreateNamedEntityValidator<Category, CreateCategoryDTO>
    {
        public CreateCategoryValidator(CozaStoreContext context) : base(context, "Category")
        {
        }
    }
}
