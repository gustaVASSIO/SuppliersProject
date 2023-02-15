using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuppliersProject.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        [Required]
        [Display(Name="Id")]
        public int Id { get; set; }
        
        [Required]
        [StringLength(100, MinimumLength =5,ErrorMessage ="The name length must be between 5 and 100")]
        [Display(Name="Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(14,MinimumLength =14, ErrorMessage = "The CNPJ must have 14 digits")]
        [Display(Name="CNPJ")]
        public string Cnpj { get; set; }
        
        [Required]
        [Display(Name="Role")]
        public string Role { get; set; }


    }
}
