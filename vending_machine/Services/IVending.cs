using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Models;

namespace vending_machine.Services
{
    public interface IVending
    {
        Product Purchase(int productId);
        List<string> ShowAll();
        string Details(int productId);
        void InsertMoney(int amount);
        Dictionary<int, int> EndTransictionals();
    }
}
