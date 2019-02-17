#region 

using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;
using System.Web.Http;
using System.Web.Mvc;

#endregion

namespace PhoneContact.Controllers
{
	public class DepartmentController : Controller
	{
		public ActionResult Index()
		{
			var session = Session["User"]?.ToString();

			if (session == null)
				return RedirectToAction("Index", "PublicUI");

			var departments = DatabaseUtil.DepartmentService.GetList().Data;

			return View(departments);
		}

		[System.Web.Mvc.HttpPost]
		public ActionResult Post([FromBody]Department department)
		{
			if (department.Id > 0)
				DatabaseUtil.DepartmentService.UpdateById(department.Id, department);
			else
				DatabaseUtil.DepartmentService.Add(department);

			return RedirectToAction("Index", "Department");
		}

		/// <summary>
		/// TODO: If department entity has connection to other tables, it can not delete...
		/// </summary>
		/// <param name="department"></param>
		/// <returns></returns>
		[System.Web.Mvc.HttpPost]
		public ActionResult Delete([FromBody]Department department)
		{
			var response = DatabaseUtil.DepartmentService.DeleteById(department.Id).Data;

			return RedirectToAction("Index", "Department");
		}
	}
}