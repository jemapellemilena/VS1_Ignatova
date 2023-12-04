using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VS1_Ignatova.Models
{
    public class Story
    {
        // Key - поле первичный ключ
        // DatabaseGenerated(DatabaseGeneratedOption.Identity) - поле автоинкреметное
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ИД")]
        public short Id { get; set; }

        [Display(Name = "Дата"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }

        // Навигационные свойства
        [ForeignKey("IdUser")]
        [Display(Name = "Пользователь")]
        public User User { get; set; }

        [ForeignKey("IdGame")]
        [Display(Name = "игра")]
        public Game Game { get; set; }
    }
}
