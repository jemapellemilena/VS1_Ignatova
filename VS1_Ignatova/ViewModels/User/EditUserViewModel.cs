using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.ViewModels.User
{
    public class EditUserViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Введите E-mail")]
        [Display(Name = "E-mail")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Введите корретный E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Введите никнейм")]
        [Display(Name = "Никнейм")]
        public string Login { get; set; }
    }
}
