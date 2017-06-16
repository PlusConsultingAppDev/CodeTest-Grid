using Grid.Domain.Abstract;
using Grid.Domain.Concrete;
using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Grid.Web.App_Start
{
    public class IocConfig
    {
        public static void Register()
        {
            ServiceContainer container = new ServiceContainer();
            container.RegisterControllers();

            container.Register<IRepository, EFRepository>();

            container.EnableMvc();
        }
    }
}