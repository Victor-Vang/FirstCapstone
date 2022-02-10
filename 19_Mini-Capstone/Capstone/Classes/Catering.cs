using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        public List<CateringItem> items = new List<CateringItem>();
        public List<CateringItem> shoppingCart = new List<CateringItem>();


        public FileAccess data = new FileAccess();

        private int Balance = 0;


        public void InitialListCreation()
        {
            items = data.GetItemsFromFile();
        }

        public CateringItem[] GetItems()
        {
            CateringItem[] result = new CateringItem[items.Count];

            items.Sort((x, y) => x.ProductCode.CompareTo(y.ProductCode));

            for (int i = 0; i < items.Count; i++)
            {
                result[i] = items[i];
            }
            return result;
        }


        // AddMoney Method

        public bool AddMoney(int money)
        {
            if (Balance + money > 1500)
            {
                return false;
            }
            else
            {
                Balance += money;
                return true;
            }
        }

        public double ReturnCurrentBalance()
        {
            return Balance;
        }

        public bool MoveItemsToCart(CateringItem wantedItem, int quantityOfProduct)
        {
            foreach (CateringItem item in items)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    if (item.Quantity < quantityOfProduct)
                    {
                        return false;
                    }
                    foreach (CateringItem chosenItem in shoppingCart)
                    {
                        if (chosenItem.ProductCode == wantedItem.ProductCode)
                        {
                            chosenItem.Quantity += quantityOfProduct;
                        }
                        else
                        {
                            shoppingCart.Add(wantedItem);
                            wantedItem.Quantity = quantityOfProduct;
                        }
                        item.Quantity -= quantityOfProduct;
                    }
                }
            }
        }
    }
}

//todo method OrderItem() that removes selected items from running list of catering items 
//todo method AddMoney() adds funds to the customer's Current Account Balance
//todo method AddToCart(item, Qty) that adds the requested items to their cart and decrements the Qty from the 'available' list
//todo method Receipt() lists items purchased and change back amount 
//todo method ChangeBack() gives the change back amount in # of 50's, 20's, dimes, etc. NO 100's! At end, update Current Account Balance to $0