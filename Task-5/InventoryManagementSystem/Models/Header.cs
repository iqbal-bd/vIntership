using System.Net;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagementSystem.Models
{
    public class Header
    {
        [Key]
        public long PurchaseId { get; set; }

        [Required (ErrorMessage ="* PurchaseDate can't be blank")]
        public DateTime PurchaseDate { get; set; }

        [Required(ErrorMessage = "* SupplierName can't be blank")]
        public string SupplierName { get; set; }

        [Required(ErrorMessage = "* Address can't be blank")]
        public string Address { get; set; }

        [Required(ErrorMessage = "* EntryBy can't be blank")]
        public string EntryBy { get; set; }

        [Required(ErrorMessage = "* EntryDate can't be blank")]
        public DateTime EntryDate { get; set; }

        [Required(ErrorMessage = "* Remark can't be blank")]
        public String Remark { get; set; }


    }
}
