﻿using Core;
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
            services.AddDbContext<CRMContext>(options => options.UseSqlServer(@"Server=.;Database=CRM;User Id=sa;Password=1;"));
        }

        public static void AddEntityServices(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IPersonService, PersonService>();
            services.AddTransient<IDepartmentService, DepartmentService>();
        }
    }
}