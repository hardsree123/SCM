using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        public static List<SelectStatus> GetStatus()
        {

            return new List<SelectStatus>
            {
               new SelectStatus{ Id=(int)RequestStatus.Delivered, Desc = "Delivered" },
               new SelectStatus{ Id=(int)RequestStatus.Cancelled, Desc = "Cancelled" },
               new SelectStatus{ Id=(int)RequestStatus.Due, Desc = "Due" },
            };

        }

        public static List<SelectStatus> GetPriority()
        {
            return new List<SelectStatus>
            {
               new SelectStatus{ Id=(int)Priority.Immediate, Desc = "Immediate" },
               new SelectStatus{ Id=(int)Priority.Urgent, Desc = "Urgent" },
               new SelectStatus{ Id=(int)Priority.High, Desc = "High" },
               new SelectStatus{ Id=(int)Priority.Medium, Desc = "Medium" },
               new SelectStatus{ Id=(int)Priority.Low, Desc = "Low" },
            };
        }

        public static string GetStatusDesc(int p)
        {
            switch (p)
            {
                case (int)Priority.Immediate: return "Immediate";
                case (int)Priority.Urgent: return "Urgent";
                case (int)Priority.High: return "High";
                case (int)Priority.Medium: return "Medium";
                case (int)Priority.Low: return "Low";
                case (int)RequestStatus.Delivered: return "Delivered";
                case (int)RequestStatus.Cancelled: return "Cancelled";
                case (int)RequestStatus.Due: return "Due";
                default:
                    return "Due";
            }
        }
    }

    public class SelectStatus
    {
        [Key]
        public int Id { get; set; }
        public string Desc { get; set; }
    }

    public class ItemStatus
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Stock status")]
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
    
    public enum Priority
    {
        Immediate = 102001,
        Urgent = 102002,
        High = 102003,
        Medium = 102004,
        Low = 102005
    }

    public enum RequestStatus { 
        Delivered = 101001,
        Cancelled = 101002,
        Due = 101003
    }

}
