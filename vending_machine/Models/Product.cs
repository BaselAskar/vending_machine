using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Services;

namespace vending_machine.Models
{
    public abstract class Product
    {
        protected Product(string? name, double price, DateTime? expired, uint count)
        {
            if (name == null)
            {
                throw new ArgumentNullException("name is not valid....");
            }

            Id = ProductSequencer.NextId;
            Name = name;
            Price = price;
            Expired = expired;
            Count = count;
        }

        public int Id { get; init; }
        public string? Name { get; set; }
        public double Price { get; set; }
        public uint Count { get; set; }
        public DateTime? Expired { get; set; }
        public abstract string Examian { get; }
        public abstract string Use { get; }

        public override string? ToString()
        {
            string expiredText = Expired != null ? $"\nExpired: {Expired?.ToString("yyyy-MM-dd")}" : "";


            return $"Product id: {Id}" +
                 $"\nProduct name: {Name}" +
                 $"\nPrice: {Price}" +
                 $"\nCount: {Count}" +
                 expiredText;
        }
    }


}
