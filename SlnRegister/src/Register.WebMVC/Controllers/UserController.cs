using Microsoft.AspNetCore.Mvc;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;

namespace Register.WebMVC.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, personId, person, username, password, email, userType")] UserDTO user)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Save(user) > 0) return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null) return NotFound();

            var user = await _service.GetById(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, personId, person, username, password, email, userType")] UserDTO user)
        {
            if (!(id == user.id)) return NotFound();

            if (ModelState.IsValid)
            {
                if (await _service.Save(user) > 0) return RedirectToAction(nameof(Index));
            }
            return View(user);
        }
    }
}
