using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Register.Application.Service.SQLServerServices;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.WebMVC.Models;

namespace Register.WebMVC.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService _service;
        private readonly IConditionService _conditionService;

        public PatientController(IPatientService service, IConditionService conditionService)
        {
            _service = service;
            _conditionService = conditionService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["conditionId"] = new SelectList(await _conditionService.GetAll(), "id", "name", "Select...");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, conditionId, personId, numMR")] PatientDTO patient)
        {
            if(ModelState.IsValid)
            {
                if (await _service.Save(patient) > 0) return RedirectToAction(nameof(Index)); 
            }
            ViewData["conditionId"] = new SelectList(await _conditionService.GetAll(), "id", "name", "Select...");
            //return View(patient);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            if(id == null) return NotFound();   

            var patient = await _service.GetById(id);
            ViewData["conditionId"] = new SelectList(await _conditionService.GetAll(), "id", "name", "Select...");
            return View(patient);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, personId, conditionId, mrNumber")] PatientDTO patient)
        {
            if (!(id == patient.id)) return NotFound();

            if (ModelState.IsValid)
            {
                if (await _service.Save(patient) > 0) return RedirectToAction(nameof(Index));
            }
            ViewData["conditionId"] = new SelectList(await _conditionService.GetAll(), "id", "name", "Select...");
            //return View(patient);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var returnDel = new ReturnJsonDelete()
            {
                status = "Success",
                code = "200",
            };

            try
            {
                if (await _service.Delete(id ?? 0) <= 0)
                {
                    returnDel = new ReturnJsonDelete()
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                returnDel = new ReturnJsonDelete()
                {
                    status = ex.Message,
                    code = "500",
                };
            }
            return Json(returnDel);
        }

    }
}
