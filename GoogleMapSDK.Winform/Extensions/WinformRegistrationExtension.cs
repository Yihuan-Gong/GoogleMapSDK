using Microsoft.Extensions.DependencyInjection;
using MVPExtension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoogleMapSDK.Winform.Extensions
{
    public static class WinformRegistrationExtension
    {
        public static void AddWinformRegistration(this IServiceCollection serviceCollection)
        {
            serviceCollection.RegisterAllViewsAndPresenters(null);
        }
    }
}
