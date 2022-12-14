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
        private readonly VendingData _vendingData;

        public VendingMachineService(VendingData vendingData)
        {
            _vendingData = vendingData;
        }

        public double TotalAmount { get => _vendingData.TotalAmount; }

        public List<int> ValidMoney { get => new List<int> { 1, 5, 10, 20, 50, 100, 500, 1000 }; } 

        public string Details(int productId)
        {
            Product? product = _vendingData.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("This product is not existed!");
            }

            return $"{product.Examian} \n" +
                $"\n" + $"Use: \n" + 
                $"{product.Use}";
        }

        public Dictionary<int, int> EndTransictionals()
        {
            Dictionary<int,int> result = new Dictionary<int, int>();
            double moneyLeft = _vendingData.TotalAmount;

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

            _vendingData.AddAmmount(amount);
        }

        public Product Purchase(int productId)
        {
            Product? product = _vendingData.Products.FirstOrDefault(p => p.Id == productId);

            if (product == null)
            {
                throw new Exception("This product is not existed!");
            }

            if (product.Count == 0)
            {
                throw new Exception("This product is not existed right now...!");
            }

            if (product.Price > _vendingData.TotalAmount)
            {
                throw new Exception("There is not enough money!");
            }

            if (product.Expired < DateTime.Now)
            {
                throw new Exception("This product has been expired!!!...");
            }

            _vendingData.DecreaseAmount(product.Price);
            product.Count--;


            return product;
        }

        public List<string> ShowAll()
        {
            return _vendingData.Products.Select(p => p.ToString()).ToList();
        }
    }
}
