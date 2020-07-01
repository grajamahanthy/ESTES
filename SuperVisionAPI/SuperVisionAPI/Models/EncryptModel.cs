using System.ComponentModel.DataAnnotations;

namespace SuperVisionAPI.Models
{
    public class EncryptModel
    {
        [Display(Name = "Input Text")]
        [Required(ErrorMessage = "Please enter input string.")]
        public string DecryptedText { get; set; }

        [Display(Name = "Key")]
        public string Key { get; set; }

        [Display(Name = "Salt")]
        public string Salt { get; set; }

        [Display(Name = "Encrypted Text")]
        public string EncryptedText { get; set; }

    }

    public class DecryptModel
    {
        [Display(Name = "Encrypted Text")]
        [Required(ErrorMessage = "Please enter encrypted string.")]
        public string EncryptedText { get; set; }

        [Display(Name = "Key")]
        public string Key { get; set; }

        [Display(Name = "Salt")]
        public string Salt { get; set; }

        [Display(Name = "Decrypted Text")]
        public string DecryptedText { get; set; }
    }
}