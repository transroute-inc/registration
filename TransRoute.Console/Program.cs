 
using System.Data.Entity;
using System.Linq;
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
                var rec = app.Queryable().ToList();
            }

            // var srv = new ArchiveNoTest();
        }
    }

}
