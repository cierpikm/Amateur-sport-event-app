using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using ServerCode.ChatHubs;
using ServerCode.Model;
using ServerCode.Model.Database;
using ServerCode.Model.Interfaces;
using ServerCode.Model.Repositories;

namespace ServerCode
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var dbConnectionString = @"Server=(localdb)\mssqllocaldb;Database=AmateurSportsEvents;Trusted_Connection=True";
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(dbConnectionString));
            services.AddDbContext<DatabaseHistoryContext>(options => options.UseSqlServer(dbConnectionString));
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAdvertisementRepository, AdvertisementRepository>();
            services.AddScoped<IBaseRepository<Achievement>, AchievementRepository>();
            services.AddScoped<IBaseRepository<SportName>, PrefferedSportsRepository>();
            services.AddScoped<IBaseRepository<Event>, EventRepository>();
            services.AddScoped<IBaseRepository<Sponsor>, SponsorRepository>();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IAdvertisementRepositoryHistory, AdvertisementArchRepository>();
            services.AddScoped<IForumRepository, ForumRepository>();
            services.AddDefaultIdentity<User>().AddEntityFrameworkStores<DatabaseContext>();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });

            var key = System.Text.Encoding.UTF8.GetBytes(Configuration["ApplicationSetting:JwtSecret"].ToString());
            //JWT Authentication 
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = false;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
                x.Events = new JwtBearerEvents
                {
                    OnMessageReceived = context =>
                    {
                        var accessToken = context.Request.Query["access_token"];

                        // If the request is for our hub...
                        var path = context.HttpContext.Request.Path;
                        if (!string.IsNullOrEmpty(accessToken) &&
                            (path.StartsWithSegments("/chatHub")))
                        {
                            // Read the token out of the query string
                            context.Token = accessToken;
                        }
                        return Task.CompletedTask;
                    }
                };
            });


            services.AddSignalR();
            services.AddAutoMapper();
            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(x => x
                 .WithOrigins("http://localhost:4200")
                 .AllowAnyMethod()
                 .AllowCredentials()
                 .AllowAnyHeader());
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseAuthentication();

            app.UseSignalR(routes =>
            {
                routes.MapHub<ChatHub>("/chatHub");
            });


            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
