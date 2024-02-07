using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Display(Name = "Produit")]
        [Required(ErrorMessage = "Le nom est requis.")]
        [StringLength(20, MinimumLength = 2, ErrorMessage = "Nom entre 2 et 20 caractères")]
        public string? NameProduct { get; set; }
        [Display(Name = "Liste des produits")]
        public string? ListProducts { get; set; }
    }
}
