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


        //todo call a method that creates list of catering items that is constructed from file
        //todo first menu should have 3 options 1. (1) Display Catering Items    (2) Order    (3) Quit
        //todo option (1) - DisplayList() from Catering class
        //todo The list of catering items displayed must be formatted so columns align, and all items are listed in `alphabetical order by product code` (eg. A1, A2, A3, A4, B1, B2, etc.).


        //todo submenu when picking (2)
        /*  (1) Add Money
            (2) Select Products
            (3) Complete Transaction
            Current Account Balance: $0.00
         */
        //todo when selecting option (1) - method AddMoney() 
        //todo when selecting option (2) - method AddToCart() & method DisplayList()
        //todo handle exception if customer enters item code that does not exist and return them to purchase menu
        //todo If a product is sold out, the customer is informed and returned to the Purchase menu (sub menu).
        //todo If not enough of the product is in stock for the quantity the customer requested then they should be informed there is 'insufficient stock'.

        //todo when selecting (3) - Receipt()  & ChangeBack() & Audit()


        private Catering catering = new Catering();

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("This is the UserInterface");
                Console.ReadLine();
            }

        }
    }
}
