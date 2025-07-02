using ECommerceApp.API.Middleware;
using ECommerceApp.Business.Mapping;
using ECommerceApp.Business.Services;
using ECommerceApp.Data.Context;
using ECommerceApp.Data.Repositories;
using ECommerceApp.Entities.Validator;
using Microsoft.EntityFrameworkCore;


namespace ECommerceApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers();


            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped<IFeatureService, FeatureService>();

            builder.Services.AddControllers()
                    .AddFluentValidation(fv =>
                        {
                            fv.RegisterValidatorsFromAssemblyContaining<FeatureDtoValidator>();
                        });

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

            // Configure the HTTP request pipeline.
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
