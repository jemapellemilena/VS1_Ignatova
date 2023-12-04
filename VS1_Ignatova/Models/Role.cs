using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VS1_Ignatova.Models
{
    public class Role
    {
        // Key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкреметное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }
        [Required(ErrorMessage = "Введите роль ")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Роль")]
        public string RoleUser { get; set; }

        // Навигационные свойства
        [Required]
        public ICollection<User> Users { get; set; }
    }
}
