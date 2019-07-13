using System;
using Microsoft.AspNetCore.Identity;

namespace EShop.Domain.Entities
{
    public class ShopUser : IdentityUser
    {
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public string Address { get; private set; }

        public DateTime RegisterDate { get; private set; }

        private ShopUser() { }

        public ShopUser(string login, string firstName, string lastName, string phone, string email,
                        string address)
        {
            SetUserName(login);
            SetFirstName(firstName);
            SetLastName(lastName);
            SetPhone(phone);
            SetEmail(email);
            SetAddress(address);
            //TODO: reg time
        }

        private void SetUserName(string login)
        {
            if(string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("login is empty", nameof(login));
            }

            UserName = login;
        }

        public void SetFirstName(string firstName)
        {
            if(string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentException("firstName is empty", nameof(firstName));
            }

            FirstName = firstName;
        }

        public void SetLastName(string lastName)
        {
            if(string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentException("lastName is empty", nameof(lastName));
            }

            LastName = lastName;
        }

        public void SetPhone(string phone) //TODO: валидация на номер
        {
            if(string.IsNullOrWhiteSpace(phone))
            {
                throw new ArgumentException("phone is empty", nameof(phone));
            }

            PhoneNumber = phone;
        }

        public void SetEmail(string email) //TODO: валидация на почту
        {
            if(string.IsNullOrWhiteSpace(email))
            {
                throw new ArgumentException("phone is empty", nameof(email));
            }

            Email = email;
        }

        public void SetAddress(string address)
        {
            if(string.IsNullOrWhiteSpace(address))
            {
                throw new ArgumentException("address is empty", nameof(address));
            }

            Address = address;
        }
    }
}