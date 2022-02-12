using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {

        public Catering()
        {
            ItemDirectory = Data.GetItemsFromFile();
        }

        public List<CateringItem> ItemDirectory = new List<CateringItem>();

        public List<CateringItem> ShoppingCart = new List<CateringItem>();

        public FileAccess Data = new FileAccess();

        private double Balance = 0;


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

        public bool AddMoney(double money)
        {
            if (Balance + money > 1500)
            {
                return false;
            }
            else
            {
                Balance += money;
                Data.AuditAddMoney(money, Balance);
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
                    result.Name = item.Name;
                    result.Price = item.Price;
                    result.Type = item.Type;
                    result.ProductCode = item.ProductCode;
                    result.Quantity = item.Quantity;
                }
            }
            return result;
        }

        public bool SoldOutChecker(CateringItem wantedItem)
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

            if ((wantedItemsValue) < Balance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IsItemInShoppingCart(CateringItem wantedItem)
        {
            bool result = false;
            foreach (CateringItem item in ShoppingCart)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    result = true;
                }
            }
            return result;
        }

        public void MoveItemsToCart(CateringItem wantedItem, int quantityOfProduct)
        {
            if (IsItemInShoppingCart(wantedItem))
            {
                foreach (CateringItem item in ShoppingCart)
                {
                    if (item.ProductCode == wantedItem.ProductCode)
                    {
                        item.Quantity += quantityOfProduct;
                    }
                }
            }
            else
            {
                wantedItem.Quantity = quantityOfProduct;
                ShoppingCart.Add(wantedItem);
            }
            foreach (CateringItem item in ItemDirectory)
            {
                if (item.ProductCode == wantedItem.ProductCode)
                {
                    item.Quantity -= quantityOfProduct;
                }
            }
            Balance -= (wantedItem.Price * quantityOfProduct);
            Data.AuditItemsBought(quantityOfProduct, wantedItem.Name, wantedItem.ProductCode, (wantedItem.Price * quantityOfProduct), Balance);
        }

        public string[] Receipt()
        {
            string[] result = new string[ShoppingCart.Count];

            for (int i = 0; i < ShoppingCart.Count; i++)
            {
                string itemType = "";
                string message = "";
                switch (ShoppingCart[i].Type)
                {
                    case "A":
                        itemType = "Appetizer";
                        message = "You might need extra plates.";
                        break;
                    case "B":
                        itemType = "Beverage";
                        message = "Don't forget ice.";
                        break;
                    case "D":
                        itemType = "Dessert";
                        message = "Coffee goes with dessert.";
                        break;
                    case "E":
                        itemType = "Entree";
                        message = "Did you remember dessert.";
                        break;
                }

                string quantity = ShoppingCart[i].Quantity.ToString();
                string price = ShoppingCart[i].Price.ToString("C");
                string totalCost = (ShoppingCart[i].Price * ShoppingCart[i].Quantity).ToString("C");

                result[i] = ($"{quantity.PadRight(5, ' ')}{itemType.PadRight(15, ' ')}{ShoppingCart[i].Name.PadRight(25, ' ')}{price.PadRight(8, ' ')}{totalCost.PadLeft(8, ' ')}  {message}");
            }
            return result;
        }

        public double AmountDue()
        {
            double result = 0;
            foreach (CateringItem item in ShoppingCart)
            {
                result += (item.Price * item.Quantity);
            }
            return result;
        }

        public string ChangeToReturn()
        {
            int numberOf100s = 0;
            int numberOf50s = 0;
            int numberOf20s = 0;
            int numberOf10s = 0;
            int numberOf5s = 0;
            int numberOf1s = 0;
            int numberOfQuarters = 0;
            int numberOfDimes = 0;
            int numberOfNickels = 0;
            double sumOfCart = 0;
            double runningTotal = sumOfCart + Balance;
            string result = "You received";

            foreach (CateringItem item in ShoppingCart)
            {
                sumOfCart += Math.Round((item.Price * item.Quantity), 2);
            }

            Data.AuditGiveChange(runningTotal);

            while (runningTotal >= 100)
            {
                numberOf100s++;
                runningTotal -= 100;
            }
            while (runningTotal >= 50)
            {
                numberOf50s++;
                runningTotal -= 50;
            }
            while (runningTotal >= 20)
            {
                numberOf20s++;
                runningTotal -= 20;
            }
            while (runningTotal >= 10)
            {
                numberOf10s++;
                runningTotal -= 10;
            }
            while (runningTotal >= 5)
            {
                numberOf5s++;
                runningTotal -= 5;
            }
            while (runningTotal >= 1)
            {
                numberOf1s++;
                runningTotal -= 1;
            }
            while (runningTotal >= 0.25)
            {
                numberOfQuarters++;
                runningTotal -= 0.25;
            }
            while (runningTotal >= 0.10)
            {
                numberOfDimes++;
                runningTotal -= 0.10;
            }
            while (runningTotal >= 0.05)
            {
                numberOfNickels++;
                runningTotal -= 0.05;
            }

            if (numberOf100s != 0)
            {
                result += ($" ({numberOf100s}) Hundreds,");
            }
            if (numberOf50s != 0)
            {
                result += ($" ({numberOf50s}) Fifties,");
            }
            if (numberOf20s != 0)
            {
                result += ($" ({numberOf20s}) Twenties,");
            }
            if (numberOf10s != 0)
            {
                result += ($" ({numberOf10s}) Tens,");
            }
            if (numberOf5s != 0)
            {
                result += ($" ({numberOf5s}) Fives,");
            }
            if (numberOf1s != 0)
            {
                result += ($" ({numberOf1s}) Ones,");
            }
            if (numberOfQuarters != 0)
            {
                result += ($" ({numberOfQuarters}) Quarters,");
            }
            if (numberOfDimes != 0)
            {
                result += ($" ({numberOfDimes}) Dimes,");
            }
            if (numberOfNickels != 0)
            {
                result += ($" ({numberOfNickels}) Nickels,");
            }

            result = result.Substring(0, result.Length - 1) + " in change.";  //either -1 or -2

            return result;
        }

        public void EndOfTransaction()
        {
            Balance = 0;
            ShoppingCart.Clear();
        }
    }
}
