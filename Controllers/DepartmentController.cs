using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using school_departments.Resources;
using System.Data;
using System.Text.Json.Serialization;

namespace school_departments.Controllers
{
    [ApiController]
    [Route("department")]
    public class DepartmentController : ControllerBase
    {
        [HttpGet]
        [Route("listDepartments")]
        public dynamic ListDepartments()
        {
            DataTable tDepartments = DBData.List("dept.list_departments");

            string deptJSON = JsonConvert.SerializeObject(tDepartments);
            return new
            {
                success = true,
                message = "success",
                data = deptJSON
            };
        }
    }
}
