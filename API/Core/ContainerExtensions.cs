using Application;
using Application.UseCases.Commands.Brands;
using Application.UseCases.Commands.Carts;
using Application.UseCases.Commands.Categories;
using Application.UseCases.Commands.Colors;
using Application.UseCases.Commands.Discounts;
using Application.UseCases.Commands.Genders;
using Application.UseCases.Commands.Messages;
using Application.UseCases.Commands.Orders;
using Application.UseCases.Commands.PaymentTypes;
using Application.UseCases.Commands.Products;
using Application.UseCases.Commands.Sizes;
using Application.UseCases.Commands.Users;
using Application.UseCases.Commands.UsersBillingAddresses;
using Application.UseCases.Queries.Brands;
using Application.UseCases.Queries.Carts;
using Application.UseCases.Queries.Categories;
using Application.UseCases.Queries.Colors;
using Application.UseCases.Queries.Discounts;
using Application.UseCases.Queries.Genders;
using Application.UseCases.Queries.Messages;
using Application.UseCases.Queries.Orders;
using Application.UseCases.Queries.PaymentTypes;
using Application.UseCases.Queries.Products;
using Application.UseCases.Queries.Sizes;
using Application.UseCases.Queries.Users;
using Application.UseCases.Queries.UsersBillingAddresses;
using Implementation.Logging.UseCases;
using Implementation.UseCases;
using Implementation.UseCases.Commands;
using Implementation.UseCases.Commands.Brands;
using Implementation.UseCases.Commands.Carts;
using Implementation.UseCases.Commands.Categories;
using Implementation.UseCases.Commands.Colors;
using Implementation.UseCases.Commands.Discounts;
using Implementation.UseCases.Commands.Genders;
using Implementation.UseCases.Commands.Messages;
using Implementation.UseCases.Commands.Orders;
using Implementation.UseCases.Commands.PaymentTypes;
using Implementation.UseCases.Commands.Products;
using Implementation.UseCases.Commands.Sizes;
using Implementation.UseCases.Commands.Users;
using Implementation.UseCases.Commands.UsersBillingAddresses;
using Implementation.UseCases.Queries;
using Implementation.UseCases.Queries.Brands;
using Implementation.UseCases.Queries.Carts;
using Implementation.UseCases.Queries.Categories;
using Implementation.UseCases.Queries.Colors;
using Implementation.UseCases.Queries.Discounts;
using Implementation.UseCases.Queries.Genders;
using Implementation.UseCases.Queries.Messages;
using Implementation.UseCases.Queries.Orders;
using Implementation.UseCases.Queries.PaymentTypes;
using Implementation.UseCases.Queries.Products;
using Implementation.UseCases.Queries.Sizes;
using Implementation.UseCases.Queries.Users;
using Implementation.UseCases.Queries.UsersBillingAddresses;
using Implementation.Validators.Brands;
using Implementation.Validators.Carts;
using Implementation.Validators.Categories;
using Implementation.Validators.Colors;
using Implementation.Validators.Discounts;
using Implementation.Validators.Genders;
using Implementation.Validators.Messages;
using Implementation.Validators.Orders;
using Implementation.Validators.PaymentTypes;
using Implementation.Validators.Products;
using Implementation.Validators.Sizes;
using Implementation.Validators.Users;
using Implementation.Validators.UsersBillingAddresses;
using System.IdentityModel.Tokens.Jwt;

namespace API.Core
{
    public static class ContainerExtensions
    {
        public static void AddUseCases(this IServiceCollection services)
        {

            services.AddTransient<IUseCaseLogger, EfUseCaseLogger>();
            services.AddTransient<UseCaseHandler>();
            services.AddTransient<GenericCreateService>();
            services.AddTransient<GenericUpdateService>();
            services.AddTransient<GenericDeleteService>();
            services.AddTransient<GenericPagedResponse>();

            
            services.AddTransient<IRegisterUserCommand, EfRegisterUserCommand>();
            
            services.AddTransient<IUpdateUserCommand, EfUpdateUserCommand>();
            services.AddTransient<IDeleteUserCommand, EfDeleteUserCommand>();
            services.AddTransient<IGetUsersQuery, EfGetUsersQuery>();
            services.AddTransient<IUpdateUserImageCommand, EfUpdateUserImageCommand>();
            
            services.AddTransient<ICreateCategoryCommand, EfCreateCategoryCommand>(); 
            services.AddTransient<IUpdateCategoryCommand, EfUpdateCategoryCommand>();       
            services.AddTransient<IDeleteCategoryCommand, EfDeleteCategoryCommand>();
            services.AddTransient<IGetCategoriesQuery, EfGetCategoriesQuery>();

            services.AddTransient<ICreateBrandCommand, EfCreateBrandCommand>();
            services.AddTransient<IUpdateBrandCommand, EfUpdateBrandCommand>();
            services.AddTransient<IDeleteBrandCommand, EfDeleteBrandCommand>();
            services.AddTransient<IGetBrandsQuery, EfGetBrandsQuery>();

            services.AddTransient<ICreateColorCommand, EfCreateColorCommand>();   
            services.AddTransient<IUpdateColorCommand, EfUpdateColorCommand>();
            services.AddTransient<IDeleteColorCommand, EfDeleteColorCommand>();
            services.AddTransient<IGetColorsQuery, EfGetColorsQuery>();

            services.AddTransient<ICreateGenderCommand, EfCreateGenderCommand>();
            services.AddTransient<IUpdateGenderCommand, EfUpdateGenderCommand>(); 
            services.AddTransient<IDeleteGenderCommand, EfDeleteGenderCommand>();
            services.AddTransient<IGetGendersQuery, EfGetGendersQuery>();

            services.AddTransient<ICreatePaymentTypeCommand, EfCreatePaymentTypeCommand>(); 
            services.AddTransient<IUpdatePaymentTypeCommand, EfUpdatePaymentTypeCommand>();
            services.AddTransient<IDeletePaymentTypeCommand, EfDeletePaymentTypeCommand>();
            services.AddTransient<IGetPaymentTypesQuery, EfGetPaymentTypesQuery>();

            services.AddTransient<ICreateSizeCommand, EfCreateSizeCommand>();
            services.AddTransient<IUpdateSizeCommand, EfUpdateSizeCommand>();     
            services.AddTransient<IDeleteSizeCommand, EfDeleteSizeCommand>();
            services.AddTransient<IGetSizesQuery, EfGetSizesQuery>();

          
            services.AddTransient<ICreateProductCommand, EfCreateProductCommand>();
            services.AddTransient<IUpdateProductCommand, EfUpdateProductCommand>();
            services.AddTransient<IDeleteProductCommand, EfDeleteProductCommand>();
            services.AddTransient<IGetProductsQuery,EfGetProductsQuery>();

           
            services.AddTransient<ICreateDiscountCommand, EfCreateDiscountCommand>();
            services.AddTransient<IUpdateDiscountCommand, EfUpdateDiscountCommand>();
            services.AddTransient<IDeleteDiscountCommand, EfDeleteDiscountCommand>();
            services.AddTransient<IGetDiscountsQuery, EfGetDiscountsQuery>();

            
            services.AddTransient<ICreateMessageCommand, EfCreateMessageCommand>();
            services.AddTransient<IDeleteMessageCommand, EfDeleteMessageCommand>();
            services.AddTransient<IGetMessagesQuery, EfGetMessagesQuery>();

            services.AddTransient<ICreateUserBillingAddressCommand,EfCreateUserBillingAddressCommand>();
            services.AddTransient<IUpdateUserBillingAddressCommand,EfUpdateUserBillingAddressCommand>();
            services.AddTransient<IDeleteUserBillingAddressCommand,EfDeleteUserBillingAddressCommand>();
            services.AddTransient<IGetUsersBillingAddressesQuery,EfGetUsersBillingAddressesQuery>();

            services.AddTransient<ICreateCartCommand,EfAddProductToCartCommand>();
            services.AddTransient<IUpdateProductInCartCommand,EfUpdateProductInCartCommand>();
            services.AddTransient<IDeleteProductFromCartCommand,EfDeleteProductFromCartCommand>();
            services.AddTransient<IGetCartsQuery,EfGetCartsQuery>();

            services.AddTransient<ICreateOrderCommand,EfCreateOrderCommand>();
            services.AddTransient<IDeleteOrderCommand,EfDeleteOrderCommand>();
            services.AddTransient<IGetOrdersQuery,EfGetOrdersQuery>();

        }

        public static void AddValidators(this IServiceCollection services)
        {
            services.AddTransient<RegisterUserDtoValidator>();
            services.AddTransient<UpdateUserDtoValidator>();
            services.AddTransient<UpdateUserImageValidator>();

            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<UpdateCategoryValidator>();

            services.AddTransient<CreateBrandValidator>();
            services.AddTransient<UpdateBrandValidator>();

            services.AddTransient<CreateColorValidator>();
            services.AddTransient<UpdateColorValidator>();

            services.AddTransient<CreateGenderValidator>();
            services.AddTransient<UpdateGenderValidator>();

            services.AddTransient<CreatePaymentTypeValidator>();
            services.AddTransient<UpdatePaymentTypeValidator>();

            services.AddTransient<CreateSizeValidator>();
            services.AddTransient<UpdateSizeValidator>();

            services.AddTransient<CreateProductValidator>();
            services.AddTransient<UpdateProductValidator>();

            services.AddTransient<CreateDiscountValidator>();
            services.AddTransient<UpdateDiscountValidator>();

            services.AddTransient<CreateMessageValidator>();

            services.AddTransient<CreateUserBillingAddressValidator>();
            services.AddTransient<UpdateUserBillingAddressValidator>();

            services.AddTransient<CreateCartValidator>();
            services.AddTransient<UpdateCartValidator>();

            services.AddTransient<CreateOrderValidator>();
        }

        public static Guid? GetTokenId(this HttpRequest request)
        {
            if (request == null || !request.Headers.ContainsKey("Authorization"))
            {
                return null;
            }

            string authHeader = request.Headers.Authorization.ToString();

            if (authHeader.Split("Bearer ").Length != 2)
            {
                return null;
            }

            string token = authHeader.Split("Bearer ")[1];

            var handler = new JwtSecurityTokenHandler();

            var tokenObj = handler.ReadJwtToken(token);

            var claims = tokenObj.Claims;

            var claim = claims.First(x => x.Type == "jti").Value;

            var tokenGuid = Guid.Parse(claim);

            return tokenGuid;
        }
    }
}
