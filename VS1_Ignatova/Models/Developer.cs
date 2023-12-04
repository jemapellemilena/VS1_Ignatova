using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Principal;
using Microsoft.AspNetCore.Identity;

namespace VS1_Ignatova.Models
{
    public class Developer 
    {
        // Key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкреметное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Введите название ")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Логин")]
        public string NameDeveloper { get; set; }     

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string DescriptionDeveloper { get; set; }

        // Навигационные свойства
        [Required]
        public ICollection<Game> Games { get; set; }
    }
}
