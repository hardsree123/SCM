using System;
using System.Collections.Generic;

namespace SCM.Business.DbModel
{
    public partial class Stock
    {
        public uint Id { get; set; }
        public string ItemCode { get; set; }
        public string ItemName { get; set; }
        public string VendorCode { get; set; }
        public string ItemDescription { get; set; }
        public decimal ItemUnitPrice { get; set; }
        public DateTime ItemAddedOn { get; set; }
        public DateTime? ItemStockUpdatedOn { get; set; }
        public DateTime? ItemEmptiedOn { get; set; }
        public short? ItemDiscountPer { get; set; }
        public short? ItemTaxPer { get; set; }
        public int? ItemStatus { get; set; }
        public byte[] AdditionalDetails { get; set; }
    }
}
