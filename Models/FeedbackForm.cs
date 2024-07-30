using System.ComponentModel.DataAnnotations;

namespace TPLOCAL1_MHN.Models
{
    public class FeedbackForm
    {
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? Gender { get; set; }
        [Required]
        public string? Adresse { get; set; }
        [Required]
        [RegularExpression(@"\d{5}", ErrorMessage = "Please enter a 5-digit code.")]
        public string? ZipCode { get; set; }
        [Required]
        public string? Town { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Training { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date {  get; set; }
        [Required]
        public string? Review1 { get; set; }
        [Required]
        public string? Review2 { get; set; }
    }
}
