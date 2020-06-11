#region 

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using PhoneContact.Business.Abstract;
using PhoneContact.Business.Concrete;
using PhoneContact.DataAccess;
using PhoneContact.DataAccess.Abstract;
using PhoneContact.DataAccess.Concrete.DTO;
using PhoneContact.DataAccess.Repository;

#endregion

namespace PhoneContact.Api
{
    // "api/[controller]"
    public class EmployeeController : ApiController
    {
        #region Fields

        private UnitOfWork _unitOfWork;

        private IEmployeeRepository _employeeRepository;
        private IEmployeeService _employeeService;

        #endregion

        #region Properties

        public UnitOfWork UnitOfWork => _unitOfWork = _unitOfWork ?? new UnitOfWork();

        public IEmployeeRepository EmployeeRepository => _employeeRepository = _employeeRepository ?? new EmployeeRepository(UnitOfWork.Context);
        public IEmployeeService EmployeeService => _employeeService = _employeeService ?? new EmployeeService(EmployeeRepository);

        #endregion

        #region Http Methods

        // GET: api/Employee/1
        [ResponseType(typeof(ResponseBase<Employee>))]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            ResponseBase<Employee> responseBase;

            try
            {
                responseBase = EmployeeService.GetById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<Employee>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // GET: api/Employee
        [ResponseType(typeof(ResponseBase<IList<Employee>>))]
        [HttpGet]
        public IHttpActionResult Get()
        {
            ResponseBase<List<Employee>> responseBase;

            try
            {
                responseBase = EmployeeService.GetList();
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<List<Employee>>(null)
                {
                    Message = exception.ToString(),
                    Success = false
                };
            }
            return Ok(responseBase);
        }

        // POST: api/Employee
        [ResponseType(typeof(ResponseBase<Employee>))]
        [HttpPost]
        public IHttpActionResult Post([FromBody] Employee item)
        {
            ResponseBase<Employee> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = EmployeeService.Add(item);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<Employee>(null)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // PUT: api/Employee/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Employee item)
        {
            ResponseBase<bool> responseBase;

            try
            {
                if (item == null)
                    throw new HttpResponseException(Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "that item doesn't exist anything"));

                responseBase = EmployeeService.UpdateById(id, item);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<bool>(false)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }

        // DELETE: api/Employee/1
        [ResponseType(typeof(ResponseBase<bool>))]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            ResponseBase<bool> responseBase;

            try
            {
                responseBase = EmployeeService.DeleteById(id);
            }
            catch (Exception exception)
            {
                responseBase = new ResponseBase<bool>(false)
                {
                    Success = false,
                    Message = exception.ToString()
                };
            }
            return Ok(responseBase);
        }
        #endregion
    }
}
