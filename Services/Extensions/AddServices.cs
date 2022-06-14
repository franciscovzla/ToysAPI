using Microsoft.Extensions.DependencyInjection;
using Services.Contracts;
using Services.Services;
using Services.Mapper;
using AutoMapper.Configuration;
namespace Services.Extensions
{
    public static class AddServices
    {
        public static void AddServ(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MapperConfig));
            services.AddScoped<IToyService, ToyService>();
        }
    }
}
