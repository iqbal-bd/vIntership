using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagementSystem.Models
{
    public class Detail
    {
        public long Id { get; set; }
        public long PurchaseId { get; set; }
        [ForeignKey("PurchaseId")]
        public Header header { get; set; }
        public string ItemCode { get; set; }
        public string ItemQty { get; set; }
        public string ItemUnitId { get; set; }
        public string ItemRate { get; set; }
        
    }
}
