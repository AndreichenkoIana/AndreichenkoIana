
using Autofac;
using Autofac.Extensions.DependencyInjection;
using MarketDb.Abstraction;
using MarketDb.Data;
using MarketDb.Repo;
using Microsoft.Extensions.FileProviders;

namespace MarketDb
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingProFile));

            builder.Services.AddMemoryCache(options =>
            {
                options.TrackStatistics = true;
            });
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                var connectionString = config.GetConnectionString("db");

                // Регистрация ProductsContext с использованием строки подключения
                containerBuilder.Register(c => new ProductsContext(connectionString ?? ""))
                                .InstancePerDependency();

                containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
                containerBuilder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerLifetimeScope();
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var staticFilePath = Path.Combine(Directory.GetCurrentDirectory(), "StaticFiles");
            Directory.CreateDirectory(staticFilePath);

            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(staticFilePath),
                RequestPath = "/static"
            });


            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

        }
    }
}
