using System.Collections.Generic;

namespace permissionmanagement.Constants
{
	public static class Permissions
	{
		public static List<string> GeneratePermissions(string controller)
		{
			return new List<string>()
		{
			$"Permissions.{controller}.Create",
			$"Permissions.{controller}.View",
			$"Permissions.{controller}.Edit",
			$"Permissions.{controller}.Delete",
		};
		}
		public static class Products
		{
			public const string View = "Permissions.Products.View";
			public const string Create = "Permissions.Products.Create";
			public const string Edit = "Permissions.Products.Edit";
			public const string Delete = "Permissions.Products.Delete";
		}
	}
}
