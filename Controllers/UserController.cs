using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Tasks.Dto;
using Tasks.Interfaces;
using Tasks.Models;
using Tasks.Repository;

namespace Tasks.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
