using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/*
 * The class is a highlevel DS for storing the items.
 * 
 * 
 * */
namespace SCM.Model
{
    public class Stock
    {
        public int ID { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }        
        public string ItemDescription { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public DateTime ItemAddedOn { get; set; }
        public DateTime ItemStockUpdatedOn { get; set; }
        public DateTime ItemEmptiedOn { get; set; }
        public short ItemDiscountPer { get; set; }
        public short ItemTaxPer { get; set; }
        public int ItemStatus { get; set; }

        public List<ItemStatus> ItemStatusList { get; set; }

        public Stock()
        {
            ItemStatusList = Common.GetItemStatusList();
        }
    }
    
}
