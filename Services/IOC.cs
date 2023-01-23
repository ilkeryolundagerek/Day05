using Core;
using Core.Services;
using Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Services.HR;

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
        }
    }
}
