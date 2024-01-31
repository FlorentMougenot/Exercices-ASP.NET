using System.ComponentModel.DataAnnotations;

namespace ExerciceOrnithorynque.Models
{
    public class Platypus
    {
        public int Id { get; set; }
        [Display(Name = "Nom")]
        public string? Name { get; set; }
        [Display(Name = "Taille (en centimètre)")]
        public double? Size { get; set; }
        [Display(Name = "Poids (en kilogramme)")]
        public double? Weight { get; set; }
        [Display(Name = "Apte à la nage")]
        public bool? CanSwim { get; set; }
    }
}
