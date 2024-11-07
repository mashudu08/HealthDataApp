using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthDataApp.Models
{
    public class HealthData
    {
        [Key]
        public int HealthDataId {get; set;}

        [Required]
        public string PatientId { get; set;}

        [ForeignKey("PatientId")]
        public required Patient Patient { get; set;}

        [Required]
        public DateTime Timestamp { get; set;}

        [Required]
        public double HeartRate { get; set;}

        [Required]
        public double BloodPressure { get; set;}

        private double Temperature { get; set;}
    }
}
