using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Razor.Tokenizer;
using System.Web.UI;
using Autofac;
using Autofac.Builder;
using Autofac.Core;
using Autofac.Integration.Mvc;
using Nop.Web.Framework.Mvc.Routes;
using QuanLyKho.Core.Data;
using QuanLyKho.Core.Infrastructure;
using QuanLyKho.Core.Infrastructure.DependencyManagement;
using QuanLyKho.Data;
using QuanLyKho.Services.Security;
using QuanLyKho.Web.Framework.Mvc.Routes;

namespace QuanLyKho.Web.Framework
{
    /// <summary>
    /// Dependency registrar
    /// </summary>
    public class DependencyRegistrar : IDependencyRegistrar
    {
        /// <summary>
        /// Register services and interfaces
        /// </summary>
        /// <param name="builder">Container builder</param>
        /// <param name="typeFinder">Type finder</param>
        /// <param name="config">Config</param>
        public virtual void Register(ContainerBuilder builder, ITypeFinder typeFinder)
        {
         

       
            //controllers
            builder.RegisterControllers(typeFinder.GetAssemblies().ToArray());

            //data layer
 
            builder.Register<IDbContext>(c => new MyObjectContext(ConfigurationManager.ConnectionStrings["MyConnectionString"].ToString())).InstancePerLifetimeScope();


            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();
            
        

            //work context
            //builder.RegisterType<WebWorkContext>().As<IWorkContext>().InstancePerLifetimeScope();
            //store context
            //builder.RegisterType<WebStoreContext>().As<IStoreContext>().InstancePerLifetimeScope();

            //services
            builder.RegisterType<UserService>().As<IUserService>().InstancePerLifetimeScope();
          
                
            builder.RegisterType<RoutePublisher>().As<IRoutePublisher>().SingleInstance();

         

        }

        /// <summary>
        /// Order of this dependency registrar implementation
        /// </summary>
        public int Order
        {
            get { return 0; }
        }
    }



}
