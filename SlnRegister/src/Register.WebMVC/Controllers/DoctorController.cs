using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.Domain.Entities;
using Register.WebMVC.Models;

namespace Register.WebMVC.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        private readonly ISpecialtyService _specialtyService;
        public DoctorController(IDoctorService doctorService, ISpecialtyService specialtyService)
        {
            _doctorService = doctorService;
            _specialtyService = specialtyService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _doctorService.GetAll());
        }

        public JsonResult ListJson()
        {
            return Json(_doctorService.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            ViewData["specialtyId"] = new SelectList(await _specialtyService.GetAll(), "id", "name", "Select...");
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> Create([Bind("id, specialtyId, cnpj, crm, personId")] DoctorDTO doctor)
        {
            if (ModelState.IsValid)
            {
                if (await _doctorService.Save(doctor) > 0)
                    return RedirectToAction(nameof(Index));
            }
            ViewData["specialtyId"] = new SelectList(await _specialtyService.GetAll(), "id", "name", doctor.specialtyId);
            return View(doctor);
        }
        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var doctor = await _doctorService.GetById(id);
            return View(doctor);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, specialtyId, cnpj, crm, personId")] DoctorDTO doctor)
        {
            if (!(id == doctor.id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (await _doctorService.Save(doctor) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }



        [HttpPost]
        public async Task<JsonResult> Delete(int? id)
        {
            var retDel = new ReturnJsonDelete
            {
                status = "Success",
                code = "200"
            };
            try
            {
                if (await _doctorService.Delete(id ?? 0) <= 0)
                {
                    retDel = new ReturnJsonDelete
                    {
                        status = "Error",
                        code = "400"
                    };
                }
            }
            catch (Exception ex)
            {
                retDel = new ReturnJsonDelete
                {
                    status = ex.Message,
                    code = "500"
                };
            }
            return Json(retDel);
        }
    }
}
