using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace EShop.WebUI.HostedServices
{
    public class CreateDefaultRolesHostedService : IHostedService
    {
        private readonly IServiceProvider _serviceProvider;

        public CreateDefaultRolesHostedService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            const string roleName = "Admin";
            var logger = Log.ForContext<CreateDefaultRolesHostedService>();
            logger.Debug("Создание {0} роли", roleName);
            
            using var scope = _serviceProvider.CreateScope();
            var manager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            
            if(await manager.RoleExistsAsync(roleName))
            {
                logger.Debug("Роль {0} уже создана", roleName);
                return;
            }
            
            var role = new IdentityRole(roleName);
            await manager.CreateAsync(role);
            
            logger.Debug("Роль {0} создана", roleName);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}