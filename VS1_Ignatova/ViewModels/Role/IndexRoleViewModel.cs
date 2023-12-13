using Microsoft.CodeAnalysis;
using System.Collections.Generic;

namespace VS1_Ignatova.ViewModels.Role
{
    public class IndexRoleViewModel
    {
        public IEnumerable<Role> Roles { get; set; }
        public PageViewModel PageViewModel { get; set; }
        public FilterRoleViewModel FilterRoleViewModel { get; set; }
        public SortRoleViewModel SortRoleViewModel { get; set; }
    }
}
