using System;
using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Net.Http.Headers;
using Recibos.Core.Interfaces;
using Recibos.Core.Services;
using Recibos.Infrastructure.Data;
using Recibos.Infrastructure.Filters;
using Recibos.Infrastructure.Repositories;

namespace RecibosAPI
{
    public class Startup
    {
        readonly string CORSPolicy = "_corsPolicy";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {            
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers(
                options => options.Filters.Add<GlobalExceptionFilter>()
            ).AddNewtonsoftJson(
                options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            ).ConfigureApiBehaviorOptions(
                options => { options.SuppressModelStateInvalidFilter = true;
            });

            services.AddDbContext<ReceiptsDBContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("ReceiptsDB"))
                     );

            //services.AddTransient<IReceiptRepository, ReceiptRepository>();
            services.AddTransient<IReceiptService, ReceiptService>();            
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddCors(options =>
            {
                options.AddPolicy(CORSPolicy,
                builder =>
                {
                    builder.WithOrigins("http://localhost:3000/")
                        .WithHeaders(HeaderNames.ContentType, "x-custom-header")
                           .WithMethods("PUT", "DELETE", "GET", "OPTIONS");
                });
            });
            services.AddMvc(options => {
                options.Filters.Add<ValidationFilter>();
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)   
            .AddFluentValidation(options => {
                options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }            

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(CORSPolicy);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers().RequireCors(CORSPolicy);
            });
        }
    }
}
