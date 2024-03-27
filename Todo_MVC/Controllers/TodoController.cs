using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using Todo_MVC.Models;

namespace Todo_MVC.Controllers
{
    public class TodoController : Controller
    {
        // GET: Todo
        public ActionResult Index()
        {
            if (Session["userId"] != null && Session["username"] != null)
            {
                long id = long.Parse(Session["userId"].ToString());
                List<Tasks> list = DBConnect.GetAllTask(id);
                return View(list);
            }
            return RedirectToRoute("Home");
        }

        [HttpPost]
        public ActionResult Add(FormCollection formdata)
        {
            long id = long.Parse(Session["userId"].ToString());

            if (formdata != null && formdata.Count > 0)
            {
                string name = formdata["name"];
                Tasks task = new Tasks(name,false);
                DBConnect.AddTask(task, id);
            }
            List<Tasks> list = DBConnect.GetAllTask(id);
            return View("Index",list);
        }

        public ActionResult Toggle(long id, bool completed)
        {
            long userId = long.Parse(Session["userId"].ToString());

            DBConnect.ToggleTask(id,completed);
            List<Tasks> list = DBConnect.GetAllTask(userId);
            return View("Index", list);
        }

        public ActionResult Update(FormCollection formdata)
        {
            long id = long.Parse(Session["userId"].ToString());
            long id_taske= long.Parse(formdata["id"]);
            string name_taske = formdata["name"];
            DBConnect.UpdateTask(id_taske, name_taske);
            List<Tasks> list = DBConnect.GetAllTask(id);
            return View("Index", list);
        }

        public ActionResult Delete(long id)
        {
            long userId = long.Parse(Session["userId"].ToString());

            DBConnect.DeleteTask(id);

            List<Tasks> list = DBConnect.GetAllTask(userId);
            return View("Index",list);
        }
    }

    
}
