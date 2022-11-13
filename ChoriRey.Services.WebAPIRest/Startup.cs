using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using AutoMapper;

using AdsPublisher.Transversal.Mapper;
using AdsPublisher.Transversal.Common;
using AdsPublisher.InfraStructure.Data;
using AdsPublisher.InfraStructure.Repository;
using AdsPublisher.InfraStructure.Interface;
using AdsPublisher.Domain.Interface;
using AdsPublisher.Domain.Core;
using AdsPublisher.Application.Interface;
using AdsPublisher.Application.Main;
using System.Reflection;
using AdsPublisher.Transversal.Logging;
using AdsPublisher.Services.WebAPIRest.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

using Newtonsoft.Json.Serialization;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace AdsPublisher.Services.WebAPIRest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            services.AddMvc(options =>
            {
                options.SuppressAsyncSuffixInActionNames = false;
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowSpecificOrigin", builder =>
                    builder.AllowAnyHeader()
                           .AllowAnyMethod()
                           .AllowAnyOrigin()
                );
            });

            //Devolver el JSON tal cual como está el modelo
            services.AddControllers()
                    .AddNewtonsoftJson(options =>
                    {
                        options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    });

            services.AddControllersWithViews().SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddJsonOptions(options => options.JsonSerializerOptions.WriteIndented = true);

            var appSettingsSection = Configuration.GetSection("Config");
            services.Configure<AppSettings>(appSettingsSection);

            //configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();

            //Se especifican la vida útil de los servicios.
            services.AddSingleton<IConfiguration>(Configuration);
            services.AddSingleton<IConnectionFactory, ConnectionFactory>();

            //Se usa de Scoped o de ámbito porque necesitamos que se instancie una vez por solicitud
            services.AddScoped<IClientesApplication, ClientesApplication>();
            services.AddScoped<IClientesDomain, ClientesDomain>();
            services.AddScoped<IClientesRepository, ClientesRepository>();

            services.AddScoped<IMicroEmpresasApplication, MicroEmpresasApplication>();
            services.AddScoped<IMicroEmpresasDomain, MicroEmpresasDomain>();
            services.AddScoped<IMicroEmpresasRepository, MicroEmpresasRepository>();

            services.AddScoped<IPQRSApplication, PQRSApplication>();
            services.AddScoped<IPQRSDomain, PQRSDomain>();
            services.AddScoped<IPQRSRepository, PQRSRepository>();

            services.AddScoped<IParametrosApplication, ParametrosApplication>();
            services.AddScoped<IParametrosDomain, ParametrosDomain>();
            services.AddScoped<IParametrosRepository, ParametrosRepository>();

            services.AddScoped<IDescriptionDynamicApplication, DescriptionDynamicApplication>();
            services.AddScoped<IDescriptionDynamicDomain, DescriptionDynamicDomain>();
            services.AddScoped<IDescriptionDynamicRepository, DescriptionDynamicRepository>();

            services.AddScoped<IFacturasApplication, FacturasApplication>();
            services.AddScoped<IFacturasDomain, FacturasDomain>();
            services.AddScoped<IFacturasRepository, FacturasRepository>();

            services.AddScoped<IPlanesApplication, PlanesApplication>();
            services.AddScoped<IPlanesDomain, PlanesDomain>();
            services.AddScoped<IPlanesRepository, PlanesRepository>();

            services.AddScoped<IHistorialPagosApplication, HistorialPagosApplication>();
            services.AddScoped<IHistorialPagosDomain, HistorialPagosDomain>();
            services.AddScoped<IHistorialPagosRepository, HistorialPagosRepository>();

            services.AddScoped<IHistorialRegistroApplication, HistorialRegistroApplication>();
            services.AddScoped<IHistorialRegistroDomain, HistorialRegistroDomain>();
            services.AddScoped<IHistorialRegistroRepository, HistorialRegistroRepository>();            

            services.AddScoped<ICategoriaApplication, CategoriaApplication>();
            services.AddScoped<ICategoriaDomain, CategoriaDomain>();
            services.AddScoped<ICategoriaRepository, CategoriaRepository>();

            services.AddScoped<ISubCategoriasApplication, SubCategoriasApplication>();
            services.AddScoped<ISubCategoriasDomain, SubCategoriasDomain>();
            services.AddScoped<ISubCategoriasRepository, SubCategoriasRepository>();

            services.AddScoped<ICategoriasPorMicroEmpresasApplication, CategoriasPorMicroEmpresasApplication>();
            services.AddScoped<ICategoriasPorMicroEmpresasDomain, CategoriasPorMicroEmpresasDomain>();
            services.AddScoped<ICategoriasPorMicroEmpresasRepository, CategoriasPorMicroEmpresasRepository>();

            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var IsSuer = appSettings.IsSuer;
            var Audience = appSettings.Audience;

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(x =>
                {
                    x.Events = new JwtBearerEvents
                    {
                        OnTokenValidated = context =>
                        {
                            var userId = int.Parse(context.Principal.Identity.Name);
                            return Task.CompletedTask;
                        },
                        OnAuthenticationFailed = context =>
                        {
                            if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
                            {
                                context.Response.Headers.Add("Token-Expired", "true");
                            }
                            return Task.CompletedTask;
                        }
                    };
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = false;
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ValidateIssuer = true,
                        ValidIssuer = IsSuer,
                        ValidateAudience = true,
                        ValidAudience = Audience,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            //services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors("AllowSpecificOrigin");
            
            app.UseRouting();
            
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Could Not Find Anything");
            });
        }
    }
}
