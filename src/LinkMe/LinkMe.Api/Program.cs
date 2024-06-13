
using LinkMe.Infrastructure.Mapping;

using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace LinkMe.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
//            builder.Services.AddDbContext<Infrastructure.Mapping.LinkMeDbContext>(options =>
//options.UseSqlite(builder.Configuration.GetConnectionString(@$"data source=D:\Projects\GitHub\Learnhub\link-me\src\LinkMe\linkme.db")));
            //string id = "data source=D:\\Projects\\GitHub\\Learnhub\\link-me\\src\\LinkMe\\linkme.db";

            //var sqlitebuilder = new SqliteConnectionStringBuilder()
            //{
            //    DataSource = id,
            //    Mode = SqliteOpenMode.Memory,
            //    Cache = SqliteCacheMode.Shared
            //};

            //var connection = new SqliteConnection(sqlitebuilder.ConnectionString);
            //connection.Open();
            //connection.EnableExtensions(true);

            //builder.Services.AddDbContext<LinkMeDbContext>(options => options.UseSqlite(connection));

            builder.Services.AddDbContext<LinkMeDbContext>(options => options.UseSqlServer("server=(local)\\SQLExpress;database=linkme;integrated Security=SSPI"));

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
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
