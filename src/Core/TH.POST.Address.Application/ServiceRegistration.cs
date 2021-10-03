using Microsoft.Extensions.DependencyInjection;
using System;

namespace TH.POST.Address.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationRegistration(this IServiceCollection services)
        {
            //var assm = Assembly.GetExecutingAssembly();

            //services.AddAutoMapper(assm);
            //services.AddMediatR(assm);

            //services.AddTransient<ISmsSender, SmsSender>();
            //services.AddTransient<IHqOnlineService, OnlineService>();
        }
    }
}
