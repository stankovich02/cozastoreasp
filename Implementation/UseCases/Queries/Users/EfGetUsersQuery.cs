using Application.DTO;
using Application.DTO.Sizes;
using Application.DTO.Users;
using Application.UseCases.Queries.Users;
using DataAccess;
using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Implementation.UseCases.Queries.Users
{
    public class EfGetUsersQuery : EfUseCase, IGetUsersQuery
    {
        private readonly GenericPagedResponse _response;
        public EfGetUsersQuery(CozaStoreContext context, GenericPagedResponse response) : base(context)
        {
            _response = response;
        }

        public int Id => 2;

        public string Name => "Search Users";

        public PagedResponse<UserDTO> Execute(SearchUser search)
        {
            return _response.ReturnPagedResponse<User, UserDTO, SearchUser>(search, Context, (query, search) =>
            {
                if (!string.IsNullOrEmpty(search.Keyword))
                {
                    query = query.Where(x => x.Username.ToLower().Contains(search.Keyword.ToLower()) || x.FirstName.ToLower().Contains(search.Keyword.ToLower()));
                }
                if (search.MinOrders.HasValue && search.MinOrders.Value > 0)
                {
                    query = query.Where(x => x.Orders.Count() >= search.MinOrders);
                }
                if (search.IsActive.HasValue)
                {
                    if (search.IsActive.Value)
                    {
                        query = query.Where(x => x.IsActive);
                    }
                    else
                    {
                        query = query.Where(x => !x.IsActive);
                    }
                }
                return query;
            },
           query => query.Select(x => new UserDTO
           {
               Username = x.Username,
               FirstName = x.FirstName,
               LastName = x.LastName,
               Email = x.Email,
               Id = x.Id,
               OrdersCount = x.Orders.Count(),
               ImagePath = x.Image.Path,
               Status = x.IsActive ? "Active" : "Inactive"
           }).ToList());
        }
    }
}
