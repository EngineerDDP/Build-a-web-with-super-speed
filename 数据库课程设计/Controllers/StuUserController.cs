using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StuUserController : Controller
    {
        private readonly SchoolContext _context;
        public StuUserController(SchoolContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
        /// <summary>
        /// 学生登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult> Login(StuLoginViewModel model)
        {
            var student = await _context.Student.SingleOrDefaultAsync(
                q => q.ID == model.ID && q.Password == model.Password);
            if(student == null)
            {
                return View(model);
            }
            return RedirectToAction("Index/" + model.ID);
        }

        // GET: StuUser/Details/5
        public async Task<ActionResult> Index(int? id)
        {
            if (id == null)
                return NotFound();
            var student = await _context.Student
                .Include(q => q.belongs)
                .ThenInclude(q => q.Belongs)
                .Include(s => s.Choices)
                .ThenInclude(c => c.Take)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.ID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet]
        public ActionResult Choice(int? id)
        {
            SchoolManagement.Models.StuUser.ChoiceLesn choice = new Models.StuUser.ChoiceLesn()
            {
                id = id.Value
            };
            return View(choice);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Choice(SchoolManagement.Models.StuUser.ChoiceLesn choice)
        {
            var student = await _context.Student.Include(q => q.Choices).SingleOrDefaultAsync(s => s.ID == choice.id);
            var course = await _context.Lesson.SingleOrDefaultAsync(l => l.Name == choice.LessonName);
            if (student != null && course != null)
            {
                student.Choices.Add(new Models.Choice()
                {
                    Stu = student,
                    Take = course
                });
                await _context.SaveChangesAsync();
                return RedirectToAction("Index/" + choice.id);
            }
            else
            {
                return View(choice);
            }
        }

        // GET: StuUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: StuUser/Edit/5
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

        // GET: StuUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: StuUser/Delete/5
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