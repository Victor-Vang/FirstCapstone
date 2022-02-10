using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface
    {

        //private FileAccess data = new FileAccess();

        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.


        private Catering catering = new Catering();

        public void RunInterface()
        {

            catering.InitialListCreation();

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
                        AddToCartText();
                        DisplayUpdatedListOfItems();
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


        public void MainMenuText()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
        }

        public void SubMenuText()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine();
            Console.WriteLine($"Current Account Balance: {Math.Round(catering.ReturnCurrentBalance(), 2):C}");
        }

        public void DisplayUpdatedListOfItems()
        {
            CateringItem[] productsAvailable;  
            Console.WriteLine("Product Code   Description   Qty   Price");

            productsAvailable = catering.GetItems();

            foreach (CateringItem item in productsAvailable)
            {
                if (item.Quantity < 1)
                {
                    Console.WriteLine($"{item.ProductCode}  {item.Name}  SOLD OUT  {item.Price}");
                }
                else
                {
                    Console.WriteLine($"{item.ProductCode}  {item.Name}  {item.Quantity}  {item.Price}");
                }
            }

        }

        public void AddMoneyText()
        {
            Console.WriteLine("Please insert bill (valid bill amounts are 1, 5, 10, 20, 50, 100): ");
            int depositedBill = int.Parse(Console.ReadLine());
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
            string productCodeInput = Console.ReadLine();

            Console.Write("Please enter the quantity: ");
            int quantityOfProducts = int.Parse(Console.ReadLine());
        }
    }
}


        //todo The list of catering items displayed must be formatted so columns align


        //todo SUBMENU handle exception if customer enters item code that does not exist and return them to purchase menu
        //todo SUBMENU If a product is sold out when trying to order, the customer is informed and returned to the Purchase menu (sub menu).
        //todo SUBMENU If not enough of the product is in stock for the quantity the customer requested then they should be informed there is 'insufficient stock'.
        //todo SUBMENU when selecting (3) - Receipt()  & ChangeBack() & Audit()