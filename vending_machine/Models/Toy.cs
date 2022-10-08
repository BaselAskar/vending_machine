using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine.Models
{
    public class Toy : Product
    {
        public Toy(string? name,double price,uint count,ToyType type):base(name,price,null,count)
        {
            Type = type;
        }

        public ToyType Type { get; set; }
        public override string Examian => Name +
                                          $"\nType: {Type}" +
                                          $"\nPrice: {Price}";

        public override string Use
        {
            get
            {
                if (Type == ToyType.Structure)
                {
                    return "Follow the intstructions to assembile the toy";
                }

                return "It's ready .... enjoy";

                
            }
        }
    }


    public enum ToyType
    {
        Ready,
        Structure
    }
}
