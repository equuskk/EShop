using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Users.Queries.AuthUser
{
    public class AuthUserCommand : IRequest<string>
    {
        public string UserName { get; }
        public string Password { get; }

        [JsonConstructor]
        public AuthUserCommand(string password, string userName)
        {
            Password = password;
            UserName = userName;
        }
    }
}