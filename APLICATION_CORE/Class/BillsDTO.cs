using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APLICATION_CORE.Class
{
    /// <summary>
    /// Created By :Saul Cruz
    /// Date Created:12/02/2023
    /// Models a BillIDs
    /// </summary>
    public class BillsDTO
    {

        [Key]
        public Guid BillID { get; set; }
        public Guid CustomerID { get; set; }
        public DateTime DateBill { get; set; }
        public String? DescriptionBill { get; set; }
        public float ValueBill { get; set; }
        public Guid UserCreated { get; set; }


    }
}

