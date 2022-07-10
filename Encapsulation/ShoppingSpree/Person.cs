namespace ShoppingSpree
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person
    {
        private string name;
        private decimal money;
        private readonly ICollection<Product> products;

        public Person()
        {
            this.products = new List<Product>();
        }

        public Person(string name, decimal money)
            : this()
        {
            this.Name = name;
            this.Money = money;
        }
        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }
                this.name = value;
            }
        }
        public decimal Money
        {
            get { return money; }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }
                this.money = value;
            }
        }

        public IReadOnlyCollection<Product> Products
         => (IReadOnlyCollection<Product>)this.products;

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (this.products.Count == 0)
            {
                sb.Append($"{this.Name} - Nothing bought");
            }
            else
            {
                int counter = 0;
                sb.Append($"{this.Name} - ");
                foreach (var product in this.products)
                {
                    counter++;
                    if (counter < this.products.Count)
                    {
                        sb.Append($"{product.Name}, ");
                    }
                    else
                    {
                        sb.Append($"{product.Name}");
                    }
                }
            }
            return sb.ToString().TrimEnd();
        }
    }
}
