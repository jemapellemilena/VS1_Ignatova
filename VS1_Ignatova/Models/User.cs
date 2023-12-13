using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VS1_Ignatova.Models
{
    public class User : IdentityUser
    {
        //дополнительные поля для каждого пользователя
        //для преподавателя могут понадобиться данные о ФИО

        [Required(ErrorMessage = "Введите никнейм")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Никнейм")]
        public string Login { get; set; }   

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Дата регистрации"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        // Навигационные свойства
        // свойство нужно для более правильного отображения данных в представлениях
       
        [Required]
        public ICollection<Story> Stories { get; set; }
    }
}
