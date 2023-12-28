﻿using Api.CadastroDeProduto.Application.Mappings;
using Api.CadastroDeProduto.Application.Service;
using Api.CadastroDeProduto.Application.Service.Interfaces;
using Api.CadastroDeProduto.Infra.Data.Context;
using Api.CadastroDeProduto.Infra.Data.Repositories;
using ApiCadastroDeProduto.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.CadastroDeProduto.Infra.IoC
{
    public static class DependencyInjection
    {
        /// <summary> Injetando Banco </summary>
        public static IServiceCollection AddInfraStructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ConnectionDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IPurchaseRepository, PurchaseRepository>();
            services.AddScoped<IUnityOfWork, UnityOfWork>();

            return services;
        }

        /// <summary> Injetando AutoMapper e serviços </summary>
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(DomainToDtoMapping));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IPurchaseService, PurchaseService>();
            return services;           
        }
    }
}
