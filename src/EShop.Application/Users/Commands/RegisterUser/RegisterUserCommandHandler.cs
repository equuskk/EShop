using System;
using System.Threading;
using System.Threading.Tasks;
using EShop.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, string>
    {
        private readonly UserManager<ShopUser> _manager;

        public RegisterUserCommandHandler(UserManager<ShopUser> manager)
        {
            _manager = manager;
        }

        public async Task<string> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = new ShopUser(request.Login, request.FirstName, request.LastName, request.Phone,
                                    request.Email, request.Address);
            var result = await _manager.CreateAsync(user, request.Password);

            if(result.Succeeded)
            {
                return user.Id;
            }

            throw new ArgumentException(); //TODO:
        }
    }
}