using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HealthDataApp.Models
{
    public class Alert
    {
        [Key]
        public int AlertId { get; set; }
        [ForeignKey("PatientId")]
        public required Patient Patient { get; set; }
        [Required]
        public string AlertType { get; set; }
        [Required]
        public DateTime Timestamp { get; set; }
        public string AlertDescription { get; set; }
    }
}
