using Absence.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Absence.Controllers
{
    [Produces("application/json")]
    [Route("api/Car")]
    public class UserController : Controller
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

        // GET: api/Car
        [HttpGet]
        public IEnumerable<User> Get()
        {
            return _UserService.ReadAll();
        }
    }
}
