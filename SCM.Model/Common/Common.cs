using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCM.Model
{
    public class Common
    {
        public static List<ItemStatus> GetItemStatusList()
        {
            return new List<ItemStatus>
            {
               new ItemStatus{ Id=(int)StockStatus.InTransit, Desc = "InTransit" },
               new ItemStatus{ Id=(int)StockStatus.Delivered, Desc = "Delivered" },
               new ItemStatus{ Id=(int)StockStatus.Ordered, Desc = "Ordered" },
               new ItemStatus{ Id=(int)StockStatus.InStock, Desc = "InStock" },
               new ItemStatus{ Id=(int)StockStatus.OutOfStock, Desc = "OutOfStock" },
            };
        }
    }

    public class ItemStatus
    {
        public int Id { get; set; }
        public string Desc { get; set; }
    }

    public enum StockStatus
    {
        InTransit = 100001,
        Delivered = 100002,
        Ordered = 100003,
        InStock = 100004,
        OutOfStock = 100005
    }
}
