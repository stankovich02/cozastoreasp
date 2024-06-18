using Application.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.UseCases.Commands.Categories
{
    public interface ICreateCategoryCommand : ICommand<CreateCategoryDTO>
    {
    }
}
