#region 

using PhoneContact.Business;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

#endregion

namespace PhoneContact
{
	public class WebApiApplication : System.Web.HttpApplication
	{
		protected void Application_Start()
		{
			AreaRegistration.RegisterAllAreas();
			GlobalConfiguration.Configure(WebApiConfig.Register);
			FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
			RouteConfig.RegisterRoutes(RouteTable.Routes);
			BundleConfig.RegisterBundles(BundleTable.Bundles);

			var users = DatabaseUtil.UserService.GetList().Data;

			if (!users.Any())
			{
				DatabaseUtil.UserService.Add(new DataAccess.Concrete.DTO.User
				{
					UserName = "System",
					UserLastName = "Admin",
					UserNickName = "admin",
					UserPassword = "admin"
				});
			}
		}
	}
}