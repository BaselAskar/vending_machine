using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vending_machine.Services
{
    public class ProductSequencer
    {
        private static int productId = 0;

        public static int NextId
        {
            get
            {
                return ++productId;
            }
        }
    }
}
