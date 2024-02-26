using Gamma_News.Data;
using Gamma_News.Models;
using Gamma_News.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http;

namespace Gamma_News
{
    public class Program
    {
        public static void Main( string [ ] args )
        {
            var builder = WebApplication.CreateBuilder( args );

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString( "DefaultConnection" ) ?? throw new InvalidOperationException( "Connection string 'DefaultConnection' not found." );
            builder.Services.AddDbContext<ApplicationDbContext>( options =>
                options.UseSqlServer( connectionString ) );
            builder.Services.AddDatabaseDeveloperPageExceptionFilter( );

            builder.Services.AddDefaultIdentity<User>( options => options.SignIn.RequireConfirmedAccount = false )
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>( );
            builder.Services.AddControllersWithViews( );
            builder.Services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = true;
            });



            //register http
            builder.Services.AddHttpClient();
            //Register WeatherService and configure it to use HttpClient
            builder.Services.AddHttpClient<WeatherService>();

            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if ( app.Environment.IsDevelopment( ) )
            {
                app.UseMigrationsEndPoint( );
            }
            else
            {
                app.UseExceptionHandler( "/Home/Error" );
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts( );
            }

            app.UseHttpsRedirection( );
            app.UseStaticFiles( );

            app.UseRouting( );

            app.UseAuthorization( );

            app.MapControllerRoute(
                name: "default" ,
                pattern: "{controller=Home}/{action=Index}/{id?}" );
            app.MapRazorPages( );

            app.Run( );
        }
    }
}
