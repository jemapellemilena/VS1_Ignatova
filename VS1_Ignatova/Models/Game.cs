using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.Models
{
    public class Game
    {
        [Required(ErrorMessage = "Введите название")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Название")]
        public string NameGame { get; set; }   //отображение Фамилия вместо LastName

        [Required(ErrorMessage = "Введите email")]
        [Display(Name = "Описание")]
        public string DescriptionGame { get; set; }

        [Display(Name = "Дата добавления"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
