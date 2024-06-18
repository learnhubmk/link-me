
using LinkMe.ApplicationServices;
using LinkMe.Domain.Contracts;
using LinkMe.Infrastructure;
using LinkMe.Infrastructure.Mapping;
using LinkMe.Infrastructure.Sqlite;
using LinkMe.Infrastructure.SqlServer;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkMe.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

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
            builder.Services.AddScoped<CreateCommunity.Handler>();
            

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

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
