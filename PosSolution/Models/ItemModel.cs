using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PosSolution.Models
{
    public class ItemModel
    {
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Insert Item Name")]
        [DisplayName("Item")]
        public string item { get; set; }
        [Required(ErrorMessage = "Enter Quentity Please")]
        [DisplayName("Quentity")]
        public int quentity { get; set; }
        [Required(ErrorMessage = "Enter Price Please")]
        [DisplayName("Price")]
        public float price { get; set; }
        [Required(ErrorMessage = "Enter Amount Please")]
        [Display(Name = "Amount")]
        public float amount { get; set; }
    }
}
