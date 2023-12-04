using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.Models
{
    public class Role
    {
        [Required(ErrorMessage = "Введите роль ")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Роль")]
        public string RoleUser { get; set; }
    }
}
