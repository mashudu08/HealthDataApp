using System.ComponentModel.DataAnnotations;

namespace HealthDataApp.Models
{
    public class Patient
    {
        [Key]
       public string PatientId { get; set; }

       [Required]
       public string Name { get; set;}

        public DateTime DateofBirth { get; set;}

       public string Gender { get; set;}

        public string MedicalHistory { get; set;}

        public ICollection<HealthData> HealthData { get; set;}
        public ICollection<Alert> Alerts { get; set;}
    }
}
