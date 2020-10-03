using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BaseAdminTemplate.Web.Controllers
{
    [DisplayName("Test Controller")]
    public class TestController : Controller
    {
        [DisplayName("Test Controller Method")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
