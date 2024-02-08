using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

[AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = false)]
public class PasswordValidator : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value != null)
        {
            string password = value.ToString();

            if (IsValidPassword(password))
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Erreur ! Erreur ! Erreur ! Le mot de passe doit contenir au moins 2 majuscules, 2 minuscules, 2 chiffres, et 2 caractères spéciaux et avoir une longueur minimale de 8 caractères.");
            }
        }

        return ValidationResult.Success;
    }

    private bool IsValidPassword(string password)
    {
        return Regex.IsMatch(password, @"^(?=.*[A-Z].*[A-Z])(?=.*[a-z].*[a-z])(?=.*\d.*\d)(?=.*\W.*\W).{8,}$");
    }

}
