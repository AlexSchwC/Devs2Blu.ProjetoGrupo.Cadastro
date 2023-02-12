using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.WebMVC.Models;

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
            return View(_service.GetAll<List<PersonDTO>>());
        }

        public JsonResult ListJson()
        {
            return Json(_service.GetAll<List<PersonDTO>>());
        }

        // GET: PersonController/Details/5
        public async Task<ActionResult> DetailsAsync(int id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var person = await _service.GetById<PersonDTO>(id);
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

            var person = await _service.GetById<PersonDTO>(id);

            return View(person);
        }

        // POST: PersonController/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, [Bind("id, name, birthDate, cpf, gender")] PersonDTO person)
        {
            if(id != person.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if(await _service.Save(person) > 0)
                {
                    return RedirectToAction(nameof(Index));
                }
                
            }
            return View(person);
        }

        // POST: PersonController/Delete/5
        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var resultDel = new ReturnJsonDelete()
            {
                status = "Error",
                code = "400"      
            };

            try
            {
                if(await _service.Delete(id ?? 0) > 0)
                {
                    resultDel.status = "Success";
                    resultDel.code = "200";
                    return Json(resultDel);
                }
            }
            catch(Exception ex)
            {
                resultDel.status= ex.Message;
                resultDel.code= "500";
            }

            return Json(resultDel);
        }
    }
}
