using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace UI.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private IPersonService _service;
        public PeopleController(IPersonService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _service.GetPeopleAsync());
        }

        public IActionResult Create()
        {
            ViewData["Departments"] = new SelectList(_service.GetDepartments(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PersonDetailDTO model)
        {
            ModelState.Remove("DepartmentName");
            ModelState.Remove("DepartmentDescription");
            if (ModelState.IsValid)
            {
                _service.Add(model);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Departments = new SelectList(_service.GetDepartments(), "Id", "Name", model.DepartmentId);
            return View(model);
        }

        public IActionResult Edit(int id)
        {
            var model = _service.GetPersonDetail(id);
            ViewBag.Departments = new SelectList(_service.GetDepartments(), "Id", "Name", model.DepartmentId);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PersonDetailDTO model)
        {
            ModelState.Remove("DepartmentName");
            ModelState.Remove("DepartmentDescription");
            model.Id = id;
            if (ModelState.IsValid)
            {
                _service.Update(model);
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Departments = new SelectList(_service.GetDepartments(), "Id", "Name", model.DepartmentId);
            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var model = _service.GetPersonDetail(id);
            return View(model);
        }
    }
}
