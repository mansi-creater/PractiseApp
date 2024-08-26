using BLL.UserController;
using DAL.UserController;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity;
using Unity.AspNet.WebApi;

namespace PractiseApp
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);
            RegisterComponents();
        }

        private static void RegisterComponents()
        {
            var container = new UnityContainer();
            container.RegisterType<IUserControllerBLL, UserControllerBLL>();
            container.RegisterType<IUserControllerDAL, UserControllerDAL>();

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}
