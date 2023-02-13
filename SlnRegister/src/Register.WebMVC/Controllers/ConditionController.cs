using Microsoft.AspNetCore.Mvc;
using Register.Domain.Contracts.Services;
using Register.Domain.DTO;
using Register.WebMVC.Models;
using System.Collections.Generic;

namespace Register.WebMVC.Controllers
{
    public class ConditionController : Controller
    {
        private readonly IConditionService _service;

        public ConditionController(IConditionService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(_service.GetAll());
        }

        public JsonResult ListJson()
        {
            return Json(_service.GetAll());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("id, name")] ConditionDTO condition)
        {
            if (ModelState.IsValid)
            {
                if (await _service.Save(condition) > 0)
                    return RedirectToAction(nameof(Index));
            }

            return View(condition);
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var condition = await _service.GetById(id);
            return View(condition);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int? id, [Bind("id, name")] ConditionDTO condition)
        {
            if (!(id == condition.id))
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                if (await _service.Save(condition) > 0)
                    return RedirectToAction(nameof(Index));
            }
            return View(condition);
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
                if (await _service.Delete(id ?? 0) <= 0)
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
