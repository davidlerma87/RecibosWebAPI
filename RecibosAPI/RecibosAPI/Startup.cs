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
using Microsoft.OpenApi.Models;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

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
            ).AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                options.SerializerSettings.NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore;
            })
            .ConfigureApiBehaviorOptions(options =>
            {
                //options.SuppressModelStateInvalidFilter = true;
            });

            //services.AddOptions(Configuration);
            services.AddDbContext<ReceiptsDBContext>(options =>
                        options.UseSqlServer(Configuration.GetConnectionString("ReceiptsDB"))
                     );
            services.AddSwaggerGen(doc => {
                doc.SwaggerDoc("v1", new OpenApiInfo { Title = "Receipts API Documentation", Version = "v1" });
            });

            //$"{Assembly.GetExecutingAssembly().GetName().Name}.xml");
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };

            });

            //services.AddTransient<IReceiptRepository, ReceiptRepository>();
            services.AddTransient<IReceiptService, ReceiptService>();            
            services.AddTransient<ICurrencyService, CurrencyService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ISecurityRepository, SecurityRepository>();
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

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "Receipts Doc API V1");
                options.RoutePrefix = string.Empty;
            });

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
