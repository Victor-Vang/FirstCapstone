using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        public List<CateringItem> ItemDirectory = new List<CateringItem>();
        public List<CateringItem> shoppingCart = new List<CateringItem>();
        public double shoppingCartBalance = 0;


        public FileAccess data = new FileAccess();

        private double Balance = 0;


        public void InitialListCreation()
        {
            ItemDirectory = data.GetItemsFromFile();
        }

        public CateringItem[] GetItems()
        {
            CateringItem[] result = new CateringItem[ItemDirectory.Count];

            ItemDirectory.Sort((x, y) => x.ProductCode.CompareTo(y.ProductCode));

            for (int i = 0; i < ItemDirectory.Count; i++)
            {
                result[i] = ItemDirectory[i];
            }
            return result;
        }


        // AddMoney Method

        public bool AddMoney(double money)
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


        public bool DoesProductExist(string productCode)
        {
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == productCode)
                {
                    return true;
                }
            }
            return false;
        }

        public CateringItem ConvertCodeToItem(string productCode)
        {
            CateringItem result = new CateringItem();
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == productCode)
                {
                    result = item;
                }
            }
            return result;
        }

        public bool SoldOutChecker(CateringItem wantedItem, int quantityOfProduct)
        {
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    if (item.Quantity == 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public bool SufficientStock(CateringItem wantedItem, int quantityOfProduct)
        {
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    if (item.Quantity >= quantityOfProduct)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool SufficientFundsCheck(CateringItem wantedItem, int quantityOfProduct)
        {
            double wantedItemsValue = 0;

            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    wantedItemsValue = (item.Price * quantityOfProduct);
                }
            }

            if ((wantedItemsValue + shoppingCartBalance) < Balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public void MoveItemsToCart(CateringItem wantedItem, int quantityOfProduct)
        {
            foreach (CateringItem item in shoppingCart)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    item.Quantity += quantityOfProduct;                    
                }
                else
                {
                    wantedItem.Quantity = quantityOfProduct;
                    shoppingCart.Add(wantedItem);
                }                
            }
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    item.Quantity -= quantityOfProduct;
                }                
            }
            shoppingCartBalance += (wantedItem.Price * quantityOfProduct);
        }
    }
}



//todo method OrderItem() that removes selected items from running list of catering items 
//todo method AddMoney() adds funds to the customer's Current Account Balance
//todo method AddToCart(item, Qty) that adds the requested items to their cart and decrements the Qty from the 'available' list
//todo method Receipt() lists items purchased and change back amount 
//todo method ChangeBack() gives the change back amount in # of 50's, 20's, dimes, etc. NO 100's! At end, update Current Account Balance to $0