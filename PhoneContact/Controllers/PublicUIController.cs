#region 

using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;
using AllowAnonymousAttribute = System.Web.Http.AllowAnonymousAttribute;

#endregion

namespace PhoneContact.Controllers
{
	[AllowAnonymous]
	public class PublicUIController : Controller
	{
		public ActionResult Index()
		{
			var employees = DatabaseUtil.EmployeeService.GetList().Data;

			return View(employees);
		}

		[System.Web.Mvc.HttpPost]
		public ActionResult Post([FromBody]Employee employee)
		{
			if (employee.Id > 0)
				DatabaseUtil.EmployeeService.UpdateById(employee.Id, employee);
			else
				DatabaseUtil.EmployeeService.Add(employee);

			return RedirectToAction("Index", "PublicUI");
		}

		[System.Web.Mvc.HttpPost]
		public ActionResult Delete([FromBody]Employee employee)
		{
			var response = DatabaseUtil.EmployeeService.DeleteById(employee.Id).Data;

			return RedirectToAction("Index", "PublicUI");
		}
	}
}