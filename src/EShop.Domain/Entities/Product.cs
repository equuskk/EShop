using System;

namespace EShop.Domain.Entities
{
    public class Product
    {
        public int Id { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public double Price { get; private set; }

        public int VendorId { get; private set; }
        public int CategoryId { get; private set; }

        public virtual Vendor Vendor { get; private set; }
        public virtual Category Category { get; private set; }

        //TODO: category & image

        private Product()
        {
        }

        public Product(string title, string description, double price, int vendorId, int categoryId)
        {
            SetPrice(price);
            SetTitle(title);
            SetDescription(description);
            SetVendorId(vendorId);
            SetCategoryId(categoryId);
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

        public void SetVendorId(int vendorId)
        {
            if(vendorId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(vendorId), vendorId,
                                                      "vendorId cannot be less than or equal to 0");
            }

            VendorId = vendorId;
        }

        public void SetCategoryId(int categoryId)
        {
            if(categoryId <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(categoryId), categoryId,
                                                      "categoryId cannot be less than or equal to 0");
            }

            CategoryId = categoryId;
        }
    }
}