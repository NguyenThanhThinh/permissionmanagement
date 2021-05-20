using Microsoft.AspNetCore.Identity;
using permissionmanagement.Constants;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace permissionmanagement.Seeds
{
	public static class DefaultUsers
	{
		public static async Task SeedBasicUserAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var defaultUser = new IdentityUser
			{
				UserName = "thanhthinhcntt@gmail.com",
				Email = "thanhthinhcntt@gmail.com",
				EmailConfirmed = true
			};
			if (userManager.Users.All(u => u.Id != defaultUser.Id))
			{
				var user = await userManager.FindByEmailAsync(defaultUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(defaultUser, "Thanh@123");
					await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
				}
			}
		}
		public static async Task SeedSuperAdminAsync(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
		{
			var defaultUser = new IdentityUser
			{
				UserName = "admin@gmail.com",
				Email = "admin@gmail.com",
				EmailConfirmed = true
			};
			if (userManager.Users.All(u => u.Id != defaultUser.Id))
			{
				var user = await userManager.FindByEmailAsync(defaultUser.Email);
				if (user == null)
				{
					await userManager.CreateAsync(defaultUser, "Thanh@123");
					await userManager.AddToRoleAsync(defaultUser, Roles.Basic.ToString());
					await userManager.AddToRoleAsync(defaultUser, Roles.Admin.ToString());
					await userManager.AddToRoleAsync(defaultUser, Roles.SuperAdmin.ToString());
				}
				await roleManager.SeedClaimsForSuperAdmin();
			}
		}
		private async static Task SeedClaimsForSuperAdmin(this RoleManager<IdentityRole> roleManager)
		{
			var adminRole = await roleManager.FindByNameAsync("SuperAdmin");
			await roleManager.AddPermissionClaim(adminRole, "Products");
		}
		public static async Task AddPermissionClaim(this RoleManager<IdentityRole> roleManager, IdentityRole role, string module)
		{
			var allClaims = await roleManager.GetClaimsAsync(role);
			var allPermissions = Permissions.GeneratePermissions(module);
			foreach (var permission in allPermissions)
			{
				if (!allClaims.Any(a => a.Type == "Permission" && a.Value == permission))
				{
					await roleManager.AddClaimAsync(role, new Claim("Permission", permission));
				}
			}
		}
	}
}
