
using LinkMe.ApplicationServices;
using LinkMe.ApplicationServices.Communities;
using LinkMe.Domain.Contracts;
using LinkMe.Infrastructure;
using LinkMe.Infrastructure.Database;
using LinkMe.Infrastructure.Sqlite;
using LinkMe.Infrastructure.SqlServer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApplication4.Data;

namespace LinkMe.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddMediatR(configuration=>configuration.RegisterServicesFromAssembly(typeof(RegisterCommunity).Assembly));

            //Add services to the container.

            if (builder.Environment.IsDevelopment())
            {
                var configuration = builder.Configuration;

                var provider = configuration.GetValue("Provider", "Sqlite");

                string connectionString;
                switch (provider)
                {
                    case "Sqlite":
                        connectionString = configuration.GetValue("SqliteConnection", "Data Source=linkme.db");
                        builder.Services.AddDbContext<LinkMeDbContext, LinkMeSqliteDbContext>();
                        break;
                    case "SqlServer":
                        connectionString = configuration.GetValue("SqlServerConnection", "Data Source=.\\SQLExpress;Initial Catalog=LinkMe;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");
                        builder.Services.AddDbContext<LinkMeDbContext, LinkMeSqlServerDbContext>();
                        break;
                    default:
                        throw new ArgumentException($"Unsupported provider: {provider}");
                }

                Environment.SetEnvironmentVariable("SqlConnection", connectionString);
            }
            else
                builder.Services.AddDbContext<LinkMeDbContext, LinkMeSqlServerDbContext>();

            builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddDbContext<AppDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
                .AddEntityFrameworkStores<AppDbContext>()
                .AddDefaultTokenProviders();



            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!))
                };
            });

            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminPolicy", policy => policy.RequireRole("Admin"));
                options.AddPolicy("UserPolicy", policy => policy.RequireRole("User"));
            });



            var app = builder.Build();


            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();

                using var serviceScope = app.Services.CreateScope();
                var context = serviceScope.ServiceProvider.GetRequiredService<LinkMeDbContext>();
                context.Database.Migrate(); // TODO apply migrations on production in build pipeline
            }


            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
