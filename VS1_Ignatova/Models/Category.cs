using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.Models
{
    public class Category
    {
        [Required(ErrorMessage = "Введите категорию")]   // сообщение об ошибке при валидации на стороне клиента
        [Display(Name = "Категория")]
        public string NameCategory { get; set; }   //отображение Фамилия вместо LastName

        [Required(ErrorMessage = "Введите описание")]
        [Display(Name = "Описание")]
        public string DescriptionCategory { get; set; }
    }
}
