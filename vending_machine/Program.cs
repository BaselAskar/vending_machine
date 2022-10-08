using System.Security.Cryptography.X509Certificates;
using vending_machine.Data;
using vending_machine.Services;

namespace vending_machine
{
    internal class Program
    {
        static void Main(string[] args)
        {

            VendingMachineService vendingMachine = new VendingMachineService();

            bool finish = false;

            do
            {
                OutputServices.ShowProductsList(ref vendingMachine);

                Console.WriteLine();

                char choies = OutputServices.SelectAltrnatives();

                OutputServices.ShowProductsList(ref vendingMachine);

                switch (choies)
                {
                    case '1':
                        OutputServices.InsertMoneyOutput(ref vendingMachine);
                        break;
                    case '2':
                        OutputServices.SelectProductOutput(ref vendingMachine);
                        break;
                    case '3':
                        OutputServices.EndTrasictionalOutput(ref vendingMachine);
                        finish = true;
                        break;
                    default:
                        Console.WriteLine("Worng choese");
                        break;
                }

            } while (!finish);

            

            //Console.WriteLine("Insert one of these money unit");
            //Console.WriteLine();
            //foreach (int unit in vendingMachine.ValidMoney)
            //{
            //    Console.Write($"{unit}kr ");
            //}
            //Console.WriteLine();
            //Console.Write("Input: ");
            //string? amount;

            //bool validInput;

            //do
            //{
            //    amount = Console.ReadLine();

            //    try
            //    {
            //        vendingMachine.InsertMoney(int.Parse(amount));
            //        validInput = true;
            //    }
            //    catch(Exception ex)
            //    {
            //        Console.WriteLine(ex.Message);
            //        validInput = false;
            //    }

            //}while(!validInput);

            //Console.Clear();

            //OutputServices.ShowProductsList(ref vendingMachine);

            //Console.WriteLine("Select Id of product");
            //Console.WriteLine();
            //Console.WriteLine(VendingData.TotalAmount);

            //string? selectedId = Console.ReadLine();

        }
    }
}