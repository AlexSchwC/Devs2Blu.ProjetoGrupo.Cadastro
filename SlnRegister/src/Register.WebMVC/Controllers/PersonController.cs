using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;

namespace Register.WebMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly IPersonService _service;

        public PersonController(IPersonService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            return View(_service.GetAll());
        }

        public JsonResult ListJson()
        {
            return Json(_service.GetAll());
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = await _service.GetById(id);
            return View(person);
        }

        // GET: PersonController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PersonController/Create
        [HttpPost]
        public async Task<ActionResult> Create([Bind("id, name, birthDate, cpf, gender")] PersonDTO person)
        {
            if (ModelState.IsValid)
            {
                if(await _service.Save(person) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(person);
        }

        // GET: PersonController/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = await _service.GetById(id);

            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, [Bind("id, name, birthDate, cpf, gender")] PersonDTO person)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PersonController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
