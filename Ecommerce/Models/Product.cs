using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Ecommerce.Models;

public class Product
{
    public int Id { get; set; }
    [Display(Name = "Produit")]
    [Required(ErrorMessage = "Le nom est requis.")]
    [StringLength(20, MinimumLength = 2, ErrorMessage = "Nom entre 2 et 20 caractères")]
    public string? Name { get; set; }
    [Display(Name = "Description du produit")]
    [Range(0, 120, ErrorMessage = "La description ne peut dépasser 120 caractères")]
    public string? Description { get; set; }
    [Display(Name = "Prix (en pokédollars)")]
    public float? Price { get; set; }
    [Display(Name = "Quantité en stock")]
    public int? Quantity { get; set; }
    [Display(Name = "Catégorie")]
    public int CategoryId { get; set; }
    [Display(Name = "Photo du produit")]
    public string? PicturePath { get; set; }

    [ForeignKey("CategoryId")]
    public Category Category { get; set; }
}
