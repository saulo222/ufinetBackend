using System.ComponentModel.DataAnnotations;
using System;
using DOMAIN_CORE.Class.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN_CORE.Class
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:12/02/2023
    /// Models a BillIDs
    /// </summary>
    public class Bills
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid BillID { get;  set; }
        public Guid CustomerID { get;  set; }
        public DateTime DateBill { get;  set; }
        public String? DescriptionBill { get; set; }
        public decimal ValueBill { get; set; }
        public Guid UserCreated { get; set; }


    }

    public class GetBills
    {

        public Guid BillID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime DateBill { get; set; }
        public String? DescriptionBill { get; set; }
        public decimal ValueBill { get; set; }
        public Guid UserCreated { get; set; }
        public String? CustomerName { get; set; }
        public String? EmployeeName { get; set; }
        public long NoBilld { get; set; }


    }

}
