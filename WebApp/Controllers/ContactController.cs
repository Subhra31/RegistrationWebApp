using DAL;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Repositories;
using Repositories.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Controllers
{
    public class ContactController : Controller
    {
        IUnitOfWork _uow;
        public ContactController(IUnitOfWork uow)
        {
            _uow = uow;
        }
        public IActionResult List()
        {
            var data = _uow.ContanctRepo.GetAll();
            return View(data);
        }

        public IActionResult Index(int page = 1, int pageSize = 2)
        {
            PagingModel<Repositories.Models.ContactModel> model = _uow.ContanctRepo.GetContact(page, pageSize);
            return View(model);
        }

        public IActionResult Create()
        {
            ViewBag.CountryList = _uow.CountryRepo.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Create(DAL.ContactModel model)
        {
            ModelState.Remove("ContactId");
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Please Enter Name");
            }

            if (ModelState.IsValid)
            {
                _uow.ContanctRepo.Add(model);
                _uow.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CountryList = _uow.CountryRepo.GetAll();
            return View();
        }

        public IActionResult Edit(int Id)
        {
            ViewBag.CountryList = _uow.CountryRepo.GetAll();
            DAL.ContactModel model = _uow.ContanctRepo.Find(Id);
            return View("Create", model);
        }
        [HttpPost]
        public IActionResult Edit(DAL.ContactModel model)
        {
            if (ModelState.IsValid)
            {
                _uow.ContanctRepo.Update(model);
                _uow.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.CountryList = _uow.CountryRepo.GetAll();
            return View("Create", model);
        }

        public IActionResult Delete(int Id)
        {
            _uow.ContanctRepo.Delete(Id);
            _uow.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
