using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Serilog;

namespace EShop.Application.Hangfire
{
    public class CreateRolesTask
    {
        private readonly RoleManager<IdentityRole> _manager;
        private readonly ILogger _logger;

        public CreateRolesTask(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
            _logger = Log.ForContext<CreateRolesTask>();
        }

        public async Task Execute()
        {
            _logger.Debug("Создание стандартных ролей");
            const string roleName = "Admin";

            if(await _manager.RoleExistsAsync(roleName))
            {
                _logger.Debug("Роль {0} уже создана", roleName);
                return;
            }

            var role = new IdentityRole(roleName);
            await _manager.CreateAsync(role);
            _logger.Debug("Роль успешно создана");
        }
    }
}