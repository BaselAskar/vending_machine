using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using vending_machine.Data;
using vending_machine.Models;
using vending_machine.Services;

namespace vending_machine_test.Services
{
    public class VendingFixture : IDisposable
    {
        public VendingMachineService VendingMachine { get; private set; }
        public VendingFixture()
        {
            VendingMachine = new VendingMachineService(new VendingData());
        }


        public void Dispose()
        {
            VendingMachine.EndTransictionals();
        }
    }


    public class VendingMachineServiceTest : IClassFixture<VendingFixture>
    {
        private readonly VendingMachineService vendingMachine;

        public VendingMachineServiceTest(VendingFixture vendingFixture)
        {
            vendingMachine = vendingFixture.VendingMachine;
        }



        [Theory]
        [InlineData(1, "Lemon juice" )]
        [InlineData(5,"Kebab")]
        [InlineData(7,"Logo")]
        public void Details_Test(int productId,string expected)
        {
            string result = vendingMachine.Details(productId);
            Assert.Contains(expected, result);
        }


        [Fact]
        public void Details_WorngId_Test()
        {
            string expected = "This product is not existed!";


            Exception ex = Assert.Throws<Exception>(() => vendingMachine.Details(44));

            Assert.Equal(ex.Message,expected);

        }


        [Fact]
        public void InsertNotValidMoney_Test()
        {
            string expected = "This money is not valid......";

            ArgumentException ex = Assert.Throws<ArgumentException>(() => vendingMachine.InsertMoney(250));

            Assert.Equal(expected, ex.Message);
        }


        [Fact]
        public void InsertValidMoney_Test()
        {
            double expected = 1500;

            vendingMachine.InsertMoney(500);
            vendingMachine.InsertMoney(1000);

            double result = vendingMachine.TotalAmount;

            Assert.Equal(expected,result);
;
        }


        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public void Purchase_NotExictedId_Test(int productId)
        {
            string expected = "This product is not existed!";

            Exception exception = Assert.Throws<Exception>(() => vendingMachine.Purchase(productId));

            Assert.Equal(expected, exception.Message);
        }


        [Fact]
        public void Purchase_NotExistedProduct_Test()
        {

            string expected = "This product is not existed right now...!";

            vendingMachine.InsertMoney(1000);

            Exception exception = Assert.Throws<Exception>(() => vendingMachine.Purchase(5));

            Assert.Equal(expected,exception.Message);
        }


        [Fact]
        public void Puchase_NotEnoughMoney_Test()
        {
            string expected = "There is not enough money!";

            vendingMachine.InsertMoney(20);

            Exception ex = Assert.Throws<Exception>(() => vendingMachine.Purchase(1));

            Assert.Equal(expected, ex.Message);
        }



        [Fact]
        public void Puchase_ExpiredProduct_Test()
        {
            vendingMachine.InsertMoney(1000);

            string expected = "This product has been expired!!!...";

            Exception ex = Assert.Throws<Exception>(() => vendingMachine.Purchase(3));

            Assert.Equal(expected, ex.Message);
        }


        [Theory]
        [InlineData(1,14)]
        [InlineData(2,2)]
        [InlineData(6,1)]
        public void Purchase_Success_Test(int productId,uint expected)
        {
            vendingMachine.InsertMoney(1000);

            Product product = vendingMachine.Purchase(productId);

            Assert.Equal(expected, product.Count);
        }



    }
}
