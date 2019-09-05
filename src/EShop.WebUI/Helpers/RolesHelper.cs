using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace EShop.WebUI.Helpers
{
    public class RolesHelper
    {
        public RoleManager<IdentityRole> _manager { get; set; }

        public RolesHelper(RoleManager<IdentityRole> manager)
        {
            _manager = manager;
        }

        public async Task CreateRole()
        {
            var roleName = "Admin";

            if(await _manager.RoleExistsAsync(roleName))
            {
                return;
            }

            var role = new IdentityRole(roleName);
            await _manager.CreateAsync(role);
        }
    }
}