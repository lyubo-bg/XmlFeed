using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using XMLFeed.Models;
using XMLFeed.Models.Interfaces;
using XMLFeed.Services;

namespace XMLFeed.App_Start
{
    public class AutofacConfig
    {
        public static void RegisterAutofac()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<XmlParserService>().As<IXmlParser<XElement>>().InstancePerRequest();
            builder.RegisterType<ItemBuilderService>().As<IItemBuilder<XElement>>().InstancePerRequest();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}