using System;

namespace EShop.Domain.Entities
{
    public class Vendor
    {
        public int Id { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        //TODO: image

        private Vendor() { }

        public Vendor(string name, string description)
        {
            SetName(name);
            SetDescription(description);
        }

        private void SetDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("description is empty", nameof(description));
            }

            Description = description;
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