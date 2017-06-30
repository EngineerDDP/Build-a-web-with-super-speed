using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace SchoolManagement.Controllers
{
    public class TchrUserController : Controller
    {
        SchoolContext _context;

        public TchrUserController(SchoolContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(TchLoginViewModel model)
        {
            var result = _context.Student.SingleOrDefault(
                q => q.ID == model.ID && q.Password == model.Password);
            if(result == null)
            {
                return View();
            }
            return RedirectToAction("Index/" + model.ID);
        }

        // GET: TchrUser/Details/5
        public ActionResult Index(int? id)
        {
            var tchr = _context.Teacher
                .Include(q => q.Lessons)
                .ThenInclude(q => q.Crs)
                .SingleOrDefault(q => q.Id == id.Value);
            if(tchr != null)
            {
                return View(tchr);
            }
            return View();
        }

        // GET: TchrUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TchrUser/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TchrUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TchrUser/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TchrUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TchrUser/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}