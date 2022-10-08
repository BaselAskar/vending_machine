using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine.Models
{
    public class Drink : Product
    {

        public Drink(string? name,double price,DateTime expired,uint count, Test test, DrinkType drinkType, double calories, bool alchoholFree):base(name,price,expired,count)
        {
            Test = test;
            DrinkType = drinkType;
            Calories = calories;
            AlchoholFree = alchoholFree;
        }

        public Test Test { get; set; }
        public DrinkType DrinkType { get; set; }
        public double Calories { get; set; }
        public bool AlchoholFree { get; set; }


        public override string Examian
        {
            get
            {
                string alchoholFreeText = AlchoholFree ? "\nAlchohol free" : "";

                return $"{Name}" +
                   $"\nThis {DrinkType} drink" +
                   $"\nTest: {Test}" +
                   $"\nCalories: {Calories} cal" +
                   $"\nPrice: {Price} kr" +
                   alchoholFreeText;
            }
        }


        public override string Use
        {
            get
            {

                StringBuilder useTextBuilder = new StringBuilder();

                if (DrinkType == DrinkType.Cold)
                {
                    useTextBuilder.Append("It's better to save below 25C and drink it cold");
                }
                else
                {
                    useTextBuilder.Append("It's drink hot...");
                }


                if (!AlchoholFree) 
                {
                    useTextBuilder.Append("\nIt's not allowed to under 18");
                }



                if (Expired != null)
                {
                    if (DateTime.Now <= Expired)
                    {
                         useTextBuilder.Append($"\nThis drink will be expired {Expired?.ToString("yyyy/MM/dd")}");
                    }
                    else
                    {
                        useTextBuilder.Append("\nThis drink has been expired....");
                    }
                }


                return useTextBuilder.ToString();

            }
        }
    }


    public enum DrinkType
    {
        Hot,
        Cold
    }

    public enum Test
    {
        Sweet,
        Sour,
        Salty,
        Bitter

    }

}
