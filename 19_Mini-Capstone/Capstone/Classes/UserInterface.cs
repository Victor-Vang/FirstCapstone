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

        private void UserInput()
        {
            bool done = false;
            while (!done)
            {
                MainMenu();

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        DisplayList();
                    case "2":
                        SubMenu();
                    case "3":
                        done = true;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid choice.");
                        break;
                }
            }
        }


        //todo call a method that creates list of catering items that is constructed from file
        //todo The list of catering items displayed must be formatted so columns align, and all items are listed in `alphabetical order by product code` (eg. A1, A2, A3, A4, B1, B2, etc.).


         */
        //todo when selecting option (1) - method AddMoney() 
        //todo when selecting option (2) - method AddToCart() & method DisplayList()
        //todo handle exception if customer enters item code that does not exist and return them to purchase menu
        //todo If a product is sold out, the customer is informed and returned to the Purchase menu (sub menu).
        //todo If not enough of the product is in stock for the quantity the customer requested then they should be informed there is 'insufficient stock'.

        //todo when selecting (3) - Receipt()  & ChangeBack() & Audit()

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
            Console.WriteLine("Current Account Balance: " + currentAccountBalance);
        }

        public void DisplayList()
        {
            Console.WriteLine("Product Code   Description   Qty   Price");
            foreach (KeyValuePair kvp in )

        }

    }
}

