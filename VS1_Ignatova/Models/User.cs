using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.Models
{
    public class User : IdentityUser
    {
        //дополнительные поля для каждого пользователя
        //для преподавателя могут понадобиться данные о ФИО

        [Required(ErrorMessage = "Введите логин")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Логин")]
        public string Login { get; set; }   //отображение Фамилия вместо LastName

        [Required(ErrorMessage = "Введите пароль")]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Дата регистрации"), DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }


        //навигационные свойства
        /* [Required]
         public ICollection<FormOfStudy> FormsOfStudy { get; set; }*/
    }
}
