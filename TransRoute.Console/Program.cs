 
using System.Data.Entity;
using System.Reflection;
using Autofac;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using TransRoute.Entities.Db;
using TransRoute.Service;

namespace TransRoute.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
             
            //builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());

            //var container = builder.Build();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWorkAsync>().InstancePerLifetimeScope();
            builder.RegisterType<ArchiveNoService>().As<IArchiveNoService>().InstancePerLifetimeScope();
            builder.RegisterType<Repository<ArchiveNo>>().As<IRepositoryAsync<ArchiveNo>>().InstancePerLifetimeScope();
            // DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            //builder.RegisterType<TodayWriter>().As<IDateWriter>();
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<IArchiveNoService>();
                var rec = app.Queryable();
            }

            // var srv = new ArchiveNoTest();
        }
    }

    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var registerAssemblyTypes = builder.RegisterAssemblyTypes(Assembly.Load("TransRoute.Repository"));
            registerAssemblyTypes
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var registerAssemblyTypes = builder.RegisterAssemblyTypes(Assembly.Load("TransRoute.Service"));
            registerAssemblyTypes

                .Where(t => t.Name.EndsWith("Service"))

                .AsImplementedInterfaces()

                .InstancePerLifetimeScope();
        }

    }
    public class EfModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule());
            builder.RegisterType(typeof(TransRouteEntities)).As(typeof(DbContext)).InstancePerLifetimeScope();
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWork)).InstancePerRequest();

        }

    }
}
