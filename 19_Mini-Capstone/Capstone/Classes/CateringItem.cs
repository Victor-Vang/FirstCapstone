using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        // This class should contain the definition for one catering item

        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public string ProductCode { get; set; }


          

        //todo add reminder message based on product type
        /*
        * Beverages should recommend "Don't forget Ice."
        * Entrees should recommend "Did you remember Dessert?"
        * Desserts should recommend "Coffee goes with dessert."
        * Appetizers should recommend "You might need extra plates."
        */


    }
}
