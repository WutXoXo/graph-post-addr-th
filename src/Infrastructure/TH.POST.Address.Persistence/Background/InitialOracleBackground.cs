using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using TH.POST.Address.Persistence.Context;

namespace TH.POST.Address.Persistence.Background
{
    public class InitialOracleBackground : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly ILogger<InitialOracleBackground> _logger;
        public InitialOracleBackground(IServiceProvider serviceProvider, ILogger<InitialOracleBackground> logger)
        {
            _serviceProvider = serviceProvider;
            _logger = logger;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            using (var scopeProvider = _serviceProvider.CreateScope())
            {
                var _contextFactory = scopeProvider.ServiceProvider.GetRequiredService<IDbContextFactory<AppOracleDBContext>>();
                using (var context = _contextFactory.CreateDbContext())
                {
                    await context.Database.MigrateAsync();
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
