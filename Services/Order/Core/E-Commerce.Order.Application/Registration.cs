using E_Commerce.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using E_Commerce.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace E_Commerce.Order.Application
{
    public static class Registration
    {
        public static void AddApplicationService(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GetOrderDetailByIdQueryHandler>();
            services.AddScoped<GetOrderDetailQueryHandler>();
            services.AddScoped<CreateOrderDetailCommandHandler>();
            services.AddScoped<UpdateOrderDetailCommandHandler>();
            services.AddScoped<RemoveOrderDetailCommandHandler>();
            
            services.AddScoped<GetAddressByIdQueryHandler>();
            services.AddScoped<GetAddressesQueryHandler>();
            services.AddScoped<CreateAddressCommandHandler>();
            services.AddScoped<UpdateAddressCommandHandler>();
            services.AddScoped<RemoveAddressCommandHandler>();

            services.AddMediatR(cfg=>cfg.RegisterServicesFromAssembly(typeof(Registration).Assembly));
        }
    }
}
