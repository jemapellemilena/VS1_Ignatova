using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace VS1_Ignatova.Models
{
    public class Developer 
    {
        [Required(ErrorMessage = "Введите название ")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Логин")]
        public string NameDeveloper { get; set; }     

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string DescriptionDeveloper { get; set; }
    }
}
