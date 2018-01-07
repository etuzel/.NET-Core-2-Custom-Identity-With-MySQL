using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NetCore2CustomIdentityMySQL.Data.Repository;
using NetCore2CustomIdentityMySQL.Models;

namespace NetCore2CustomIdentityMySQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly UsersRepo _usersRepo;

        public HomeController(UsersRepo usersRepo)
        {
            _usersRepo = usersRepo;
        }

        public IActionResult Index()
        {
            var model = _usersRepo.GetAll();
            return View(model);
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
