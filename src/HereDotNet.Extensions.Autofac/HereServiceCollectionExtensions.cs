using Autofac;
using HereDotNet.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace HereDotNet.Extensions.Autofac
{
    public static class HereServiceCollectionExtensions
    {
        public static ContainerBuilder RegisterHereDotNet(this ContainerBuilder builder, Action<IHereConfigurationBuilder> configure)
        {
            var autofac = new AutofacBuilder(builder);
            configure.Invoke(autofac);
            return builder;
        }
    }
}
