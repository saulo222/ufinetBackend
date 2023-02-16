using System.ComponentModel.DataAnnotations;
using System;
using DOMAIN_CORE.Class.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN_CORE.Class
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:13/02/2023
    /// Models a Customers
    /// </summary>
    public class Customers
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid CustomerID { get;  set; }
        public String NameCustomer { get;  set; }
        public String LastNameCustomer { get;  set; }


    }
}
