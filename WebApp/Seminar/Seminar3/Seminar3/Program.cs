
using Autofac.Extensions.DependencyInjection;
using Autofac;
using Microsoft.Extensions.FileProviders;
using Seminar3.Repo;
using Seminar3.Data;
using Seminar3.Abstraction;
using Seminar3.Query;
using Seminar3.Mutation;

namespace Seminar3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Configuration.GetConnectionString("db");

            builder.Services.AddMemoryCache();
            builder.Services.AddAutoMapper(typeof(MappingProFile));
            builder.Services.AddSingleton<IProductRepository, ProductRepository>();
            builder.Services.AddSingleton<IGroupRepository, GroupRepository>();
            builder.Services.AddSingleton<ProductsContext>();
            builder.Services
                .AddGraphQLServer()
                .AddQueryType<MySimpleQuery>()
                .AddMutationType<MySimpleMutation>();

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());

            builder.Host.ConfigureContainer<ContainerBuilder>(containerBuilder =>
            {
                var connectionString = config.GetConnectionString("db");
                containerBuilder.Register(c => new ProductsContext(connectionString ?? ""))
                                .InstancePerDependency();
                containerBuilder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
                containerBuilder.RegisterType<GroupRepository>().As<IGroupRepository>().InstancePerLifetimeScope();
                containerBuilder.RegisterType<StoreRepository>().As<IStoreRepository>().InstancePerLifetimeScope();
            });

            var app = builder.Build();

            app.MapGraphQL();
            app.Run();

        }
    }
}

