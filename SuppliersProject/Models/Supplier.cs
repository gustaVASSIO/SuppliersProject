using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SuppliersProject.Models
{
    [Table("suppliers")]
    public class Supplier
    {
        [Display(Name="Id")]
        public int Id { get; set; }
        [Display(Name="Name")]
        public string Name { get; set; }
        [Display(Name="CNPJ")]
        public string Cnpj { get; set; }
        [Display(Name="Role")]
        public string Role { get; set; }


    }
}
