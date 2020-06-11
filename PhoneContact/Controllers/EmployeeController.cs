#region 

using System.Net;
using System.Web.Mvc;
using PhoneContact.Business;
using PhoneContact.DataAccess.Concrete.DTO;

#endregion

namespace PhoneContact.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View(DatabaseUtil.EmployeeService.GetList().Data);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var employee = DatabaseUtil.EmployeeService.GetById(id.Value).Data;

            if (employee == null) return HttpNotFound();

            return View(employee);
        }

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EmployeeName,EmployeeLastName,EmployeePhone,EmployeeFullName,EmployeeNote")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                DatabaseUtil.EmployeeService.Add(employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var employee = DatabaseUtil.EmployeeService.GetById(id.Value).Data;

            if (employee == null) return HttpNotFound();

            return View(employee);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EmployeeName,EmployeeLastName,EmployeePhone,EmployeeFullName,EmployeeNote")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                DatabaseUtil.EmployeeService.UpdateById(employee.Id, employee);

                return RedirectToAction("Index");
            }

            return View(employee);
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null) return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var employee = DatabaseUtil.EmployeeService.GetById(id.Value).Data;

            if (employee == null) return HttpNotFound();

            return View(employee);
        }

        // POST: Employee/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DatabaseUtil.EmployeeService.DeleteById(id);

            return RedirectToAction("Index");
        }
    }
}