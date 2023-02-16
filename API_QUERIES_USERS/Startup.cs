using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Swashbuckle.AspNetCore.SwaggerUI;
using Elastic.Apm.AspNetCore;
using System.Reflection;
using MediatR;
using INFRA_TOOLS_AGGREGATES.Class.Log;
using INFRA_TOOLS_IMPLEMENTATION.Class.Log;
using INFRA_TOOLS_AGGREGATES.Class.Token;
using INFRA_TOOLS_IMPLEMENTATION.Class.Token;
using PERSITENCE_CORE.Users;
using DOMAIN_AGGREGATES.Users;
using APLICATION_AGGREGATES.Aggregates.Queries;
using APLICATION_IMPLEMENTATION.Implementation.Users.Queries;
using INFRA_TOOLS_CORE.Class.Token;

namespace ProjectManageAPI
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

         
            services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();

            ////DATABASE
            services.AddDbContext<MainContextGetUsers>(options =>
             
                 options.UseSqlServer(Configuration.GetConnectionString("databaseUsers"))
            );


            ////DEPENDENCY INJECTION

            services.AddScoped(typeof(IGetUsers), typeof(MainContextGetUsers));
            services.AddScoped(typeof(IGetUsersServices), typeof(GetUsersService));


            services.AddScoped(typeof(ILog), typeof(LogService));
            services.AddScoped(typeof(IToken), typeof(TokenService));
            //SWAGGER

            var token = Configuration.GetSection("tokenManagement").Get<TokenManagement>();
            services.AddSingleton(token);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = token.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(token.Secret)),
                    ValidAudience = token.Audience,
                    ValidateAudience = false
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "API to run queries on properties",
                    Description = "API that allows find property data"


                });
                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                //c.IncludeXmlComments(xmlPath, true);

                // add JWT Authentication
                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token **_only_**",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer", // must be lower case
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });

                // add Basic Authentication
                var basicSecurityScheme = new OpenApiSecurityScheme
                {
                    Type = SecuritySchemeType.Http,
                    Scheme = "basic",
                    Reference = new OpenApiReference { Id = "BasicAuth", Type = ReferenceType.SecurityScheme }
                };
                c.AddSecurityDefinition(basicSecurityScheme.Reference.Id, basicSecurityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {basicSecurityScheme, new string[] { }}
                });
            });


            services.AddControllers();

            




        }

        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("v1/swagger.json", "Versioned API v1.0");

                c.DocumentTitle = "Title Documentation";
                c.DocExpansion(DocExpansion.None);
            });
            

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseElasticApm(Configuration);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });



        }
    }
}
