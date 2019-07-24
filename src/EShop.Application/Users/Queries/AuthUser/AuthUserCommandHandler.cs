using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Users.Services;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Users.Queries.AuthUser
{
    public class AuthUserCommandHandler : IRequestHandler<AuthUserCommand, string>
    {
        private readonly SignInManager<ShopUser> _signInManager;
        private readonly UserManager<ShopUser> _userManager;
        private readonly GenerateTokenService _tokenService;

        public AuthUserCommandHandler(SignInManager<ShopUser> signInManager, UserManager<ShopUser> userManager,
                                      GenerateTokenService tokenService)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(AuthUserCommand request, CancellationToken cancellationToken)
        {
            var auth = await _signInManager.PasswordSignInAsync(request.UserName, request.Password,
                                                                true, false);
            if(auth.Succeeded)
            {
                var user = await _userManager.FindByNameAsync(request.UserName);
                return _tokenService.GenerateJwtToken(user);
            }

            throw new AuthenticationException("login failed");
        }
    }
}