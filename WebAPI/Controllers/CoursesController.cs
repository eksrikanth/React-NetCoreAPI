using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Courses")]
    public class CoursesController : Controller
    {
     [Route("GetCourses")]
      public string GetCourses()
        {
            return DateTime.Now.ToString();
        }

        [Route("GetPublicCourses")]
        public IActionResult GetPublicCourses()
        {
            IActionResult actionResult = this.Ok(DateTime.Now);
            return actionResult;
        }
    }
}
