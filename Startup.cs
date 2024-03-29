
using System.Text;
using clubyApi.Helper;
using clubyApi.Models;
using clubyApi.Repositories;
using clubyApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using MongoDB.Entities;

namespace clubyApi
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

            var appSettingsSection = Configuration.GetSection("AppSettings");  
            
           // var clubyDatabaseSettings = Configuration.GetSection("ClubyDatabaseSettings");  

            services.Configure < AppSettings > (appSettingsSection);  

            var appSettings = appSettingsSection.Get < AppSettings > ();  
            // services.Configure < ClubyDatabaseSettings > (clubyDatabaseSettings);  
             //var dbSettings=clubyDatabaseSettings.Get<ClubyDatabaseSettings>();
              //services.AddMongoDBEntities("ClubyDatabase","localhost",27017);

            var key = Encoding.ASCII.GetBytes(appSettings.Secret); 
            services.AddAuthentication(x => {  
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;  
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;  
            }).AddJwtBearer(x => {  
                x.RequireHttpsMetadata = false;  
                x.SaveToken = true;  
                x.TokenValidationParameters = new TokenValidationParameters {  
                    ValidateIssuerSigningKey = true,  
                        IssuerSigningKey = new SymmetricSecurityKey(key),  
                        ValidateIssuer = false,  
                        ValidateAudience = false  
                };  
            });  

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });                
            });
            services.Configure<ClubyDatabaseSettings>(
           Configuration.GetSection(nameof(ClubyDatabaseSettings)));

            services.AddSingleton<IClubyDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<ClubyDatabaseSettings>>().Value);
    
               
            
            services.AddSingleton<IStudentService,StudentService>();
            services.AddSingleton<IStudentRepository,StudentRepository>();
            services.AddSingleton<IClubService,ClubService>();
            services.AddSingleton<IClubRepository,ClubRepository>(); 
            services.AddSingleton<IEventService,EventService>();
            services.AddSingleton<IEventRepository,EventRepository>();
            services.AddSingleton<IAdministrationService,AdministrationService>();
            services.AddSingleton<IAdministrationRepository,AdministrationRepository>();
            services.AddSingleton<IUserService,UserService>();
            services.AddSingleton<IDomainRepository,DomainRepository>();
            services.AddSingleton<IDomainService,DomainService>();
            services.AddSingleton<IUserRepository,UserRepository>();
            services.AddSingleton<IInstituteService,InstituteService>();
            services.AddSingleton<IInstituteRepository,InstituteRepository>();
            services.AddSingleton<ISponsorService,SponsorService>();
            services.AddSingleton<ISponsorRepository,SponsorRepository>();
           

            services.AddControllers();
                        services.AddMvc(option => option.EnableEndpointRouting = false).SetCompatibilityVersion(CompatibilityVersion.Latest);


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthorization();
            app.UseAuthentication();

            app.UseMvc();

            app.UseHttpsRedirection();
            app.UseRouting();    
            app.UseSwagger();



             app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseCors(
             x => x.AllowAnyHeader()
            );
        }
    }
}
