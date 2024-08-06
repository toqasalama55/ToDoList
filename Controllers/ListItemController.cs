using Microsoft.AspNetCore.Mvc;
using ToDoList.Data;
using ToDoList.Models;

namespace ToDoList.Controllers
{
    public class ListItemController : Controller
    {
        ApplicationDBContext context = new ApplicationDBContext();
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]

        //create new user
        public IActionResult Create(string PersonName)
        {
            if (PersonName != null)
            {
                CookieOptions options = new CookieOptions()
                {

                    Expires = DateTime.Now.AddDays(1),
                    Path = "/"
                };
                Response.Cookies.Append("username", PersonName, options);
                return RedirectToAction("ToDoList");

            }
            return View("Create");


        }

        /// List items table
        public IActionResult ToDoList()
        {
            var username = Request.Cookies["username"];
            ViewBag.Username = username;
            var res = context.ListItems.ToList();
            return View(res);
        
        }

       
        /// Create new List item
   
        public IActionResult CreateNew()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateNew(ListItems listItems)
        {
            context.ListItems.Add(listItems);
            context.SaveChanges();
            TempData["Serial"]=listItems.Id;
            return RedirectToAction("ToDoList");

        }
        public IActionResult Edit(int Id)
        {
            var res = context.ListItems.Find(Id);
            return View(res);
        }

        public IActionResult SaveEdit(ListItems listItems)
        {
             context.ListItems.Update(listItems);
            context.SaveChanges();
            return RedirectToAction("ToDoList");

         }


        public IActionResult Delete(int id)
        {
            var res = context.ListItems.Find(id);
            if (res !=null)
            {
                context.ListItems.Remove(res);
                context.SaveChanges();
                return RedirectToAction("ToDoList");


            }
            else
            {
                return View("Index");
            }
        }
    }
}
