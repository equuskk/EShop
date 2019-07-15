using MediatR;

namespace EShop.Application.Users.Commands.AuthUser
{
    public class AuthUserCommand : IRequest<string>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}