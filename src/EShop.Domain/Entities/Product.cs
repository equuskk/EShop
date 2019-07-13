using System;

namespace EShop.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public Vendor Vendor { get; private set; }
        public Category Category { get; private set; }

        //TODO: category & image

        private Product() { }

        public Product(string title, string description, double price, Vendor vendor, Category category)
        {
            SetPrice(price);
            SetTitle(title);
            SetDescription(description);
            SetVendor(vendor);
            SetCategory(category);
        }

        public void SetTitle(string title)
        {
            if(string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("title is empty", nameof(title));
            }

            Title = title;
        }

        public void SetDescription(string description)
        {
            if(string.IsNullOrWhiteSpace(description))
            {
                throw new ArgumentException("description is empty", nameof(description));
            }

            Description = description;
        }

        public void SetPrice(double price)
        {
            if(price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price), price, "price cannot be less than or equal to 0");
            }

            Price = price;
        }

        public void SetVendor(Vendor vendor)
        {
            Vendor = vendor ?? throw new ArgumentNullException(nameof(vendor), "Vendor is null");
        }

        private void SetCategory(Category category)
        {
            Category = category ?? throw new ArgumentNullException(nameof(category), "category is null");
        }
    }
}