using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using UI.MVC.Models;

namespace UI.MVC.Controllers
{
    public class PeopleController : Controller
    {
        private IPersonService _service;
        public PeopleController(IPersonService service)
        {
            _service = service;
        }

        public IActionResult Index(int page = 1, int size = 10)
        {
            return View(new PeopleIndexViewModel(_service, page, size));
        }

        public PeopleIndexViewModel Json(int page = 1, int size = 10)
        {
            return new PeopleIndexViewModel(_service, page, size);
        }

        public IActionResult Create()
        {
            ViewData["Departments"] = new SelectList(_service.GetDepartments(), "Id", "Name");
            return View(new PersonFormViewModel(_service,"Create"));
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
            return View(new PersonFormViewModel(_service, "Create",person:model));
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
