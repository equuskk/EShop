using MediatR;

namespace EShop.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}