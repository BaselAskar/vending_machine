using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Models;

namespace vending_machine.Data
{
    public class VendingData
    {
        private List<Product> products = new List<Product>
        {
            new Drink("Lemon juice",25.99,DateTime.Parse("2023-01-15"),15,Test.Sour,DrinkType.Cold,465.53,true),
            new Drink("Tea",15.55,DateTime.Parse("2022-12-05"),3,Test.Sweet,DrinkType.Hot,152.3,true),
            new Drink("Expresso coffee",20.25,DateTime.Parse("2022-09-30"),1,Test.Bitter,DrinkType.Hot,59.5,true),
            new Drink("Wisky",89.99,DateTime.Parse("2023-02-25"),3,Test.Sweet,DrinkType.Cold,94.35,false),
            new Food("Kebab",153.56,DateTime.Parse("2023-03-15"),0,2,WeightUnit.KG,FoodTypes.Meat),
            new Food("Pizza Margarita",25,DateTime.Parse("2023-05-09"),2,350,WeightUnit.G,FoodTypes.Vegetairian),
            new Toy("Logo",60.99,4,ToyType.Structure),
            new Toy("Barby",550,3,ToyType.Ready)

        };

        public List<Product> Products { get => products; }

        


        private double totalAmount = 0;

        public double TotalAmount { get => totalAmount; }

        public void AddAmmount(double amount)
        {
            totalAmount += amount;
        }

        public void DecreaseAmount(double amount)
        {
            totalAmount -= amount;
        }


        public void ResetAmount()
        {
            totalAmount = 0;
        }
    }
}
