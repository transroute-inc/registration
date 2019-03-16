using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Repository.Pattern.DataContext;
using Repository.Pattern.Ef6;
using Repository.Pattern.Repositories;
using Repository.Pattern.UnitOfWork;
using Service.Pattern;
using TransRoute.Entities.Db;
using TransRoute.Repository.Repositories;
using TransRoute.Service;

namespace TransRoute.WebApi.App_Start
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterHttpRequestMessage(GlobalConfiguration.Configuration);

            builder.RegisterModule(new RepositoryModule());
            builder.RegisterModule(new ServiceModule());
            builder.RegisterModule(new EfModule());
            builder.RegisterModule(new GenericModule());


            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }


    }
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var registerAssemblyTypes = builder.RegisterAssemblyTypes(typeof(ArchiveNoRepository).Assembly);
            registerAssemblyTypes
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();
        }
    }
    public class GenericModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepositoryAsync<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>)).InstancePerRequest();
            builder.RegisterGeneric(typeof(Service<>))
                           .As(typeof(IService<>)).InstancePerRequest();


        }
    }
    public class ServiceModule : Autofac.Module
    {

        protected override void Load(ContainerBuilder builder)
        {
            var registerAssemblyTypes = builder.RegisterAssemblyTypes(typeof(ArchiveNoService).Assembly);
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
            builder.RegisterType(typeof(UnitOfWork)).As(typeof(IUnitOfWorkAsync)).InstancePerRequest();

        }

    }

}