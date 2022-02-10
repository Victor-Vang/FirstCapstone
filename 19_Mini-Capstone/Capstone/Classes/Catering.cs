using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        //private List<CateringItem> items = new List<CateringItem>();

        private Dictionary<string, CateringItem> items = new Dictionary<string, CateringItem>();
        
        //todo when initializing list, all items should be stocked w/ 25 Qty
        //todo method OrderItem() that removes selected items from running list of catering items 
        //todo If item has 0 Qty, it should display 'Sold out', not 0
        //todo method AddMoney() adds funds to the customer's Current Account Balance
        //todo method AddToCart(item, Qty) that adds the requested items to their cart and decrements the Qty from the 'available' list
        //todo method Receipt() lists items purchased and change back amount 
        //todo method ChangeBack() gives the change back amount in # of 50's, 20's, dimes, etc. NO 100's! At end, update Current Account Balance to $0
        //todo method InitializeList() calls to FileAcces to create initial list of items. 



   
    }
}
