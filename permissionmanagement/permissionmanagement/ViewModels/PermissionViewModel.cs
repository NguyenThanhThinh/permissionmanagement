using System.Collections.Generic;

namespace permissionmanagement.ViewModels
{
	public class PermissionViewModel
	{
		public string RoleId { get; set; }
		public IList<RoleClaimsViewModel> RoleClaims { get; set; }
	}
}
