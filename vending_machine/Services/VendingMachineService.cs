using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Data;
using vending_machine.Models;

namespace vending_machine.Services
{
    public class VendingMachineService : IVending
    {

        public List<int> ValidMoney { get => new List<int> { 1, 5, 10, 20, 50, 100, 500, 1000 }; } 

        public string Details(Product product)
        {
            return product.Examian;
        }

        public Dictionary<int, int> EndTransictionals()
        {
            Dictionary<int,int> result = new Dictionary<int, int>();
            double moneyLeft = VendingData.TotalAmount;

            for (int i= ValidMoney.Count - 1; i >= 0; i--)
            {
                if (ValidMoney[i] <= moneyLeft)
                {
                    int numberOfUnit = (int)Math.Floor(moneyLeft / ValidMoney[i]);
                    result.Add(ValidMoney[i], numberOfUnit);
                    moneyLeft -= ValidMoney[i] * numberOfUnit;
                }
            }


            return result;
        }

        public void InsertMoney(int amount)
        {
            if (!ValidMoney.Contains(amount))
            {
                throw new ArgumentException("This money is not valid......");
            }

            VendingData.AddAmmount(amount);
        }

        public Product Purchase(int productId)
        {
            Product? product = VendingData.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("This product is not existed!");
            }

            if (product.Count == 0)
            {
                throw new Exception("This product is not existed right now...!");
            }

            if (product.Price > VendingData.TotalAmount)
            {
                throw new Exception("There is not enough money!");
            }



            VendingData.DecreaseAmount(product.Price);
            product.Count--;


            return product;
        }

        public List<string> ShowAll()
        {
            return VendingData.Products.Select(p => p.ToString()).ToList();
        }
    }
}
