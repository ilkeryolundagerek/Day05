using AutoMapper;
using Core;
using Core.Services;
using Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.HR;
using Services.MapProfiles;
using Services.Middlewares;

namespace Services
{
    //Servisleri UI katmanlarına entegre etmek için kullanılacak.
    public static class IOC
    {
        public static void AddBaseServices(this IServiceCollection services)
        {
            services.AddDbContext<CRMContext>(options => options.UseSqlServer(@"Server=.;Database=CRM;User Id=sa;Password=1;MultipleActiveResultSets=true;"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IItemService, ItemService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //Özellikle hazırlanmış automapper profillerini dahil ederiz.
            var mapper_config = new MapperConfiguration(c =>
            {
                c.AddProfile(new HRProfiles());
            });
            IMapper mapper = mapper_config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }

    public static class MiddlewareExtension
    {
        public static IApplicationBuilder AddAccessKeyCheckMiddlewares(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<AccessKeyCheck>();
        }

        public static IApplicationBuilder AddExceptionCenter(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionCenter>();
        }
    }
}
