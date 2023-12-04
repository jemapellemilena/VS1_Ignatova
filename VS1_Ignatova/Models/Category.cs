using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VS1_Ignatova.Models
{
    public class Category
    {
        // Key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкреметное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Введите категорию")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Категория")]
        public string NameCategory { get; set; }   //отображение Фамилия вместо LastName

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string DescriptionCategory { get; set; }

        // Навигационные свойства
        [Required]
        public ICollection<Game> Games { get; set; }
    }
}
