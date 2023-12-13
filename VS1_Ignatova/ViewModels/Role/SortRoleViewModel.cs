using VS1_Ignatova.Models.Enums;

namespace VS1_Ignatova.ViewModels.Role
{
    public class SortRoleViewModel
    {
        public RoleSortState CodeSort { get; private set; }
        public RoleSortState NameSort { get; private set; }
        public RoleSortState Current { get; private set; }     // текущее значение сортировки

        public SortRoleViewModel(RoleSortState sortOrder)
        {
            CodeSort = sortOrder == RoleSortState.CodeAsc ?
                RoleSortState.CodeDesc : RoleSortState.CodeAsc;

            NameSort = sortOrder == RoleSortState.NameAsc ?
                RoleSortState.NameDesc : RoleSortState.NameAsc;

            Current = sortOrder;
        }
    }
}
