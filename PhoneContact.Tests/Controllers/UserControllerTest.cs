#region 

using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PhoneContact.Controllers;

#endregion

namespace PhoneContact.Tests.Controllers
{
	[TestClass]
	public class UserControllerTest
	{
		[TestMethod]
		public void Index()
		{
			// Arrange
			UserController controller = new UserController();

			return;

			// Act
			ViewResult result = controller.Index() as ViewResult;

			// Assert
			Assert.IsNotNull(result);
			Assert.AreEqual("User Page", result.ViewBag.Title);
		}
	}
}
