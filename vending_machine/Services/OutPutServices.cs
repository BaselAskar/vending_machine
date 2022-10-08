using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using vending_machine.Data;

namespace vending_machine.Services
{
    internal class OutputServices
    {
        public static void ShowProductsList(ref VendingMachineService vendingMachine)
        {
            Console.Clear();
            Console.WriteLine("******** Welcome to vending machine *******");
            Console.WriteLine();


            List<string> productList = vendingMachine.ShowAll();

            foreach (var product in productList)
            {
                Console.WriteLine(product);
                Console.WriteLine("-----------------------");
            }
            Console.WriteLine();
            Console.WriteLine($"Total input: {VendingData.TotalAmount}");
            Console.WriteLine();

        }


        public static char SelectAltrnatives()
        {
            Console.WriteLine("1. Insert money");
            Console.WriteLine();
            Console.WriteLine("2. Select Product");
            Console.WriteLine();
            Console.WriteLine("3. Return money");
            Console.WriteLine();

            char select;

            bool validSelect;

            do
            {
                select = Console.ReadKey().KeyChar;

                switch (select)
                {
                    case '1':
                    case '2':
                    case '3':
                        validSelect = true;
                        break;
                    default:
                        Console.WriteLine();
                        Alert("Wrong choies ... try agin");
                        validSelect = false;
                        break;
                }


            } while (!validSelect);

            return select;
        }



        public static void InsertMoneyOutput(ref VendingMachineService vendingMachine)
        {
            Console.WriteLine("Insert one of these money unit");
            Console.WriteLine();
            Console.WriteLine("or insert back to go back");
            Console.WriteLine();
            foreach (int unit in vendingMachine.ValidMoney)
            {
                Console.Write($"{unit}kr ");
            }
            Console.WriteLine();
            string? amount;

            bool validInput;

            do
            {
                Console.Write("Input: ");
                amount = Console.ReadLine();

                if (amount == "back") break;

                try
                {
                    vendingMachine.InsertMoney(int.Parse(amount));
                    validInput = true;
                }
                catch (Exception ex)
                {
                    Alert(ex.Message);
                    validInput = false;
                }

            } while (!validInput);

        }



        public static void SelectProductOutput(ref VendingMachineService vendingMachine)
        {
            bool purchaseIsDone = false;


            Console.WriteLine();


            do
            {
                Console.WriteLine();
                Console.WriteLine("Insert ID of product");
                Console.WriteLine("or insert 'back' to go back");

                Console.Write("ID: ");

                string? productIdText = Console.ReadLine();

                if (productIdText == "back")
                {
                    break;
                }

                int productId;

                bool isNumber = int.TryParse(productIdText, out productId);

                while (!isNumber)
                {
                    Alert("Wrong input....");

                    productIdText = Console.ReadLine();

                    isNumber = int.TryParse(productIdText, out productId);
                }


                Console.WriteLine();
                Console.WriteLine("1. buy product");
                Console.WriteLine();
                Console.WriteLine("2. Show details");
                Console.WriteLine();

                char productChoies;

                bool validChoies = false;

                do
                {
                    productChoies = Console.ReadKey().KeyChar;
                    Console.WriteLine();

                    switch (productChoies)
                    {
                        case '1':
                            try
                            {
                                validChoies = true;
                                vendingMachine.Purchase(productId);
                                purchaseIsDone = true;
                            }
                            catch (Exception ex)
                            {
                                Alert(ex.Message);
                                continue;
                            }
                            break;
                        case '2':
                            validChoies = true;
                            Console.WriteLine(vendingMachine.Details(productId));
                            break;
                        default:
                            Alert("Wrong choies");
                            break;

                    }

                } while (!validChoies);

                



            } while (!purchaseIsDone);
        }


        public static void EndTrasictionalOutput(ref VendingMachineService vendingMachine)
        {
            Dictionary<int, int> returned = vendingMachine.EndTransictionals();

            Console.WriteLine();
            Console.WriteLine("Returned money: ");
            Console.WriteLine();
            foreach(int key in returned.Keys)
            {
                Console.WriteLine(key + "kr = " + returned[key]);
            }

            Console.WriteLine();
            Console.WriteLine("Thanks for using vending machine ...... Baye Baye");

        }






        //Helper methods
        private static void Alert(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.Beep();
            Console.WriteLine(message);
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}
