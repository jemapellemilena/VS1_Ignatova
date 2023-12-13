using Microsoft.AspNetCore.Mvc.Rendering;

namespace VS1_Ignatova.ViewModels.Role
{
    public class FilterRoleViewModel
    {

        public SelectList RoleUsers { get; private set; } // список форм обучения
        public short? RoleUser { get; private set; }   // выбранная форма обучения



        /*public FilterRoleViewModel(string code, string name,
            List<FormOfStudy> formOfStudies, short? formOfEdu)
        {
            SelectedCode = code;
            SelectedName = name;

            // устанавливаем начальный элемент, который позволит выбрать всех
            formOfStudies.Insert(0, new FormOfStudy { FormOfEdu = "", Id = 0 });

            FormOfStudies = new SelectList(formOfStudies, "Id", "FormOfEdu", formOfEdu);
            FormOfEdu = formOfEdu;
        }
    }
}
