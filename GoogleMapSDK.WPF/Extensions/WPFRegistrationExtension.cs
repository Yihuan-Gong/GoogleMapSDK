using Microsoft.Extensions.DependencyInjection;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.WPF.Extensions
{
    public static class WPFRegistrationExtension
    {
        public static void AddWPFRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAllViewsAndPresenters(null);
        }
    }
}
