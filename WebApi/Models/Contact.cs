using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace WebApi.Models
{
    public class Contact
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Lastname { get; set; }
        public string FullName { get { return $"{Name} {Lastname}"; } }
        public DateTime? BirthDate { get; set; }
        public int? Age
        {
            get
            {
                if (BirthDate.HasValue)
                {
                    DateTime today = DateTime.Today;
                    int age = today.Year - BirthDate.Value.Year;
                    if (BirthDate.Value.Date > today.AddYears(-age))
                    {
                        age--;
                    }

                    return age;
                }
                return null;
            }
        }
        public string? Gender { get; set; }
    }
}
