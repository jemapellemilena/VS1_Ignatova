using System.ComponentModel.DataAnnotations;

namespace VS1_Ignatova.Models
{
    public class Story
    {
        [Display(Name = "Дата"), DataType(DataType.Date)]
        public DateTime DateAdded { get; set; }
    }
}
