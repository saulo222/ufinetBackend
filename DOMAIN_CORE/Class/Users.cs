using System.ComponentModel.DataAnnotations;
using System;
using DOMAIN_CORE.Class.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DOMAIN_CORE.Class
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:15/02/2023
    /// Models a Customers
    /// </summary>
    public class User
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid UserID { get;  set; }
        public string? NameUser { get;  set; }
        public string? LastNameUser { get;  set; }
        public string? Password { get; set; }
        public string? NameLogin { get; set; }


    }
}
