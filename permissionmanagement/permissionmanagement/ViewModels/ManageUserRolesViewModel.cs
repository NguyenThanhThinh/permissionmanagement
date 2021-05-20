using System.Collections.Generic;

namespace permissionmanagement.ViewModels
{
	public class ManageUserRolesViewModel
    {
        public string UserId { get; set; }
        public IList<UserRolesViewModel> UserRoles { get; set; }
    }
}
