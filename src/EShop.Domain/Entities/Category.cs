using System;

namespace EShop.Domain.Entities
{
    public class Category
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        private Category() { }

        public Category(string name)
        {
            SetName(name);
        }

        public void SetName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("name is empty", nameof(name));
            }

            Name = name;
        }
    }
}