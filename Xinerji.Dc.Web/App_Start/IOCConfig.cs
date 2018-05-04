using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace Xinerji.Dc.Web.App_Start
{
    public static class IOCConfig
    {
        public static void RegisterComponents()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            //container.RegisterType<AuthenticationServiceImpl, AuthenticationService>();
            //container.RegisterType<AccountServiceImpl, AccountService>();


            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}