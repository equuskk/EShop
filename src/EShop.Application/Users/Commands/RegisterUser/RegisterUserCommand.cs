using MediatR;
using Newtonsoft.Json;

namespace EShop.Application.Users.Commands.RegisterUser
{
    public class RegisterUserCommand : IRequest<string>
    {
        public string Login { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Phone { get; }
        public string Email { get; }
        public string Address { get; }

        public string Password { get; }

        [JsonConstructor]
        public RegisterUserCommand(string login, string firstName, string lastName, string phone,
                                   string email, string address, string password)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            Phone = phone;
            Email = email;
            Address = address;
            Password = password;
        }
    }
}