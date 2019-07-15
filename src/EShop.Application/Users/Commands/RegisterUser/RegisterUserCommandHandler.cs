using System.Security.Authentication;
using System.Threading;
using System.Threading.Tasks;
using EShop.Application.Users.Services;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly UserManager<ShopUser> _manager;
        private readonly GenerateTokenService _tokenService;

        public RegisterUserCommandHandler(UserManager<ShopUser> manager, GenerateTokenService tokenService)
        {
            _manager = manager;
            _tokenService = tokenService;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ShopUser(request.Login, request.FirstName, request.LastName, request.Phone,
                                    request.Email, request.Address);
            var result = await _manager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                return _tokenService.GenerateJwtToken(user);
            }

            var msg = string.Join('\n', result.Errors);
            throw new AuthenticationException(msg);
        }
    }
}