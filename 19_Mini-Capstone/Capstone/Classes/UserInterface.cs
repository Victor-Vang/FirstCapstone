using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {


        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.


        private Catering catering = new Catering();

        public void RunInterface()
        {

            bool done = false;
            
            while (!done)
            {
                MainMenuText();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        DisplayUpdatedListOfItems();
                        break;
                    case "2":
                        SubMenu();
                        break;
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }
        public void SubMenu()
        {
            bool done = false;

            while (!done)
            {
                SubMenuText();

                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case "1":
                        AddMoneyText();
                        break;
                    case "2":
                        DisplayUpdatedListOfItems();
                        AddToCartText();                        
                        break;
                    case "3":
                        DisplayReciept();
                        catering.EndOfTransaction();
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }


        public void MainMenuText()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine();
        }

        public void SubMenuText()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current Account Balance: {Math.Round(catering.ReturnCurrentBalance(), 2):C}");
            Console.WriteLine();
        }

        public void DisplayUpdatedListOfItems()
        {
            CateringItem[] productsAvailable;

            string productCode = "Product Code";
            string description = "Description";
            string quantity = "Qty";
            string price = "Price";
            

            Console.WriteLine($"{productCode.PadRight(15, ' ')}{description.PadRight(25, ' ')}{quantity.PadRight(10, ' ')}{price.PadRight(15, ' ')}");

            productsAvailable = catering.GetItems();

            foreach (CateringItem item in productsAvailable)
            {
                if (item.Quantity < 1)
                {
                    string soldOut = "SOLD OUT";
                    string priceAsString = item.Price.ToString("C");
                    Console.WriteLine($"{item.ProductCode.PadRight(15, ' ')}{item.Name.PadRight(25, ' ')}{soldOut.PadRight(10, ' ')}{priceAsString.PadRight(15, ' ')}");
                }
                else
                {
                    string quantityAsString = item.Quantity.ToString();
                    string priceAsString = item.Price.ToString("C");
                    Console.WriteLine($"{item.ProductCode.PadRight(15, ' ')}{item.Name.PadRight(25, ' ')}{quantityAsString.PadRight(10, ' ')}{priceAsString.PadRight(15, ' ')}");
                }
            }
            Console.WriteLine();
        }

        public void AddMoneyText()
        {
            Console.Write("Please insert bill (valid bill amounts are 1, 5, 10, 20, 50, 100): ");
            double depositedBill = 0;
            try
            {
                double tempDepositedBill = double.Parse(Console.ReadLine());
                depositedBill = tempDepositedBill;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Please enter a valid bill.");
                return;
            }

            if ((depositedBill == 1) || (depositedBill == 5) || (depositedBill == 10) || (depositedBill == 20) || (depositedBill == 50) ||(depositedBill == 100))
            {
                bool successfulDeposit = catering.AddMoney(depositedBill);
                if (!successfulDeposit)
                {
                    Console.WriteLine("Balance may not go over $1500.");
                }
            }
            else
            {
                Console.WriteLine("Please enter a valid bill.");
            }
        }

        public void AddToCartText()
        {
            Console.Write("Please enter the product code: ");
            string productCodeInput = Console.ReadLine().ToUpper();
            CateringItem chosenCateringItem = catering.ConvertCodeToItem(productCodeInput);
            bool exists = catering.DoesProductExist(productCodeInput);
            if (!exists)
            {
                Console.WriteLine("Product does not exist.");
                return;
            }

            Console.Write("Please enter the quantity: ");
            int quantityOfProducts = 0;

            try
            {
                int tempQuantityOfProducts = int.Parse(Console.ReadLine());
                quantityOfProducts = tempQuantityOfProducts;
            }
            catch (FormatException ex)
            {
                Console.WriteLine("Invalid quantity.");
                return;
            }

            bool soldOut = catering.SoldOutChecker(chosenCateringItem);
            if (soldOut)
            {
                Console.WriteLine("Item is SOLD OUT!");
                return;
            }
            bool haveStock = catering.SufficientStock(chosenCateringItem, quantityOfProducts);
            if (!haveStock)
            {
                Console.WriteLine("Insufficient stock.");
                return;
            }
            bool sufficentFunds = catering.SufficientFundsCheck(chosenCateringItem, quantityOfProducts);
            if (!sufficentFunds)
            {
                Console.WriteLine("Insufficient funds to add items.");
                return;
            }
            catering.MoveItemsToCart(chosenCateringItem, quantityOfProducts);
        }

        public void DisplayReciept()
        {
            string[] recieptInfo = catering.Receipt();
            for(int i = 0; i < recieptInfo.Length; i++)
            {
                Console.WriteLine(recieptInfo[i]);
            }
            Console.WriteLine();
            Console.WriteLine($"Total: {catering.AmountDue():C}");
            Console.WriteLine();
            Console.WriteLine(catering.ChangeToReturn());

        }
    }
}
