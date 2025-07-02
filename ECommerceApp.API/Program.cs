using ECommerceApp.API.Middleware;
using ECommerceApp.Business.Mapping;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Context;
using ECommerceApp.Data.Repositories;
using ECommerceApp.Entities.Validator;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddValidatorsFromAssemblyContaining<FeatureDtoValidator>();
            builder.Services.AddValidatorsFromAssemblyContaining<ProductDtoValidator>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IFeatureService, FeatureService>();
            builder.Services.AddScoped<IProductService, ProductService>();

            builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

            builder.Services.AddDbContext<ECommerceDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            var app = builder.Build();

            app.UseMiddleware<ErrorHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}