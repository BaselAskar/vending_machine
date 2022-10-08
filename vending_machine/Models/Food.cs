using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine.Models
{
    public class Food : Product
    {
        public Food(string? name,double price,DateTime expired,uint count,double weight, WeightUnit unit, FoodTypes type):base(name,price,expired,count)
        {
            if (weight <= 0)
            {
                throw new ArgumentException("This is not valid weight");
            }


            Weight = weight;
            Unit = unit;
            Type = type;
        }

        public double Weight { get; set; }
        public WeightUnit Unit { get; set; }
        public FoodTypes Type { get; set; }
        public bool Frozen { get; set; }

        public override string Examian
        {
            get
            {

                return $"{Name}" +
                      $"\nType: {Type}" +
                      $"\nWeight: {Weight} {Unit}" +
                      $"Price: {Price} kr";
            }
        }

        public override string Use
        {
            get
            {
                StringBuilder useTextBuilder = new StringBuilder();

                if (Expired != null && Expired > DateTime.Now)
                {
                    return "This product has been expired";
                }


                if (Frozen)
                {
                    useTextBuilder.Append("Frist Leave it until take off frezz");
                }

                if (Type == FoodTypes.Meat)
                {
                    useTextBuilder.Append("\nPut it in microwave for 5 minuts");
                }

                return useTextBuilder.ToString();
            }
        }
    }


    public enum FoodTypes
    {
        Meat,
        Vegetairian
    }

    public enum WeightUnit
    {
        KG,
        G,
        MG
    }
}
