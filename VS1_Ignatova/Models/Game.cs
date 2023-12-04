using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VS1_Ignatova.Models
{
    public class Game
    {
        // Key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкреметное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

        [Required(ErrorMessage = "Введите название")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Название")]
        public string NameGame { get; set; }   //отображение Фамилия вместо LastName

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Описание")]
        public string DescriptionGame { get; set; }

        [Display(Name = "Дата добавления"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        // Навигационные свойства
        [ForeignKey("IdCategory")]
        [Display(Name = "Категория")]
        public Category Category { get; set; }

        [ForeignKey("IdDeveloper")]
        [Display(Name = "Разработчик")]
        public Developer Developer { get; set; }

        [Required]
        public ICollection<Story> Stories { get; set; }
    }
}
