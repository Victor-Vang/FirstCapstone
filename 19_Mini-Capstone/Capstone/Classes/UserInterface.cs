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
                MainMenu();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayList();
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
        //todo The list of catering items displayed must be formatted so columns align



        //todo SUBMENU when selecting option (1) - method AddMoney() 
        //todo SUBMENU when selecting option (2) - method AddToCart() & method DisplayList()
        //todo SUBMENU handle exception if customer enters item code that does not exist and return them to purchase menu
        //todo SUBMENU If a product is sold out when trying to order, the customer is informed and returned to the Purchase menu (sub menu).
        //todo SUBMENU If not enough of the product is in stock for the quantity the customer requested then they should be informed there is 'insufficient stock'.
        //todo SUBMENU when selecting (3) - Receipt()  & ChangeBack() & Audit()

        public void MainMenu()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
        }

        public void SubMenu()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine();
            //Console.WriteLine("Current Account Balance: " + currentAccountBalance);
        }

        

        public void DisplayList()
        {
            CateringItem[] items;  
            Console.WriteLine("Product Code   Description   Qty   Price");

            items = catering.GetItems();

            foreach (CateringItem item in items)
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

    }
}

