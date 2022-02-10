using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        private string filePath = @"C:\Catering";

        //Dictionary<string, CateringItem> items = new Dictionary<string, CateringItem>();

        public List<CateringItem> GetItems()
        {
        List<CateringItem> itemsFromList = new List<CateringItem>();

            using (StreamReader sr = new StreamReader(filePath))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] split = line.Split("|");

                    CateringItem cateringItem = new CateringItem();

                    cateringItem.Type = split[0];
                    cateringItem.ProductCode = split[1];
                    cateringItem.Name = split[2];
                    cateringItem.Price = decimal.Parse(split[3]);
                    
                }
            }
            return itemsFromList;
        }




        // This class should contain any and all details of access to files

        //todo create a method that creates list of catering items that is constructed from file
        //todo create AuditAddMoney() that writes to file -ADD MONEY
        //todo create AuditGiveChange() that writes to file - GIVE CHANGE 
        //todo create AuditItemsBought() that writes to file - NUMBER_ORDERED PRODUCT_NAME  PRODUCT_CODE






    }

}
