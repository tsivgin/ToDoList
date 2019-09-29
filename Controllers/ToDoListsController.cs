using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ToDoList.Models;
using ToDoList.Repository;

namespace ToDoList.Controllers
{
    public class ToDoListsController : Controller
    {
        readonly IToDoList _toDosServices;
        public ToDoListsController(IToDoList ToDoList)
        {
            _toDosServices = ToDoList;
        }

        public ActionResult Index()
        {

            var model = _toDosServices.GetAllToDo();
            return View(model);
        }


        public ActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Definition,DueDate,Priority,Attribute,Reminders")] ToDoLists ToDoList)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _toDosServices.AddToDo(ToDoList);
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return View("Error", new HandleErrorInfo(e, "ToDoLists", "Create"));
                }
            }

            return View(ToDoList);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ToDoLists toDoLists = _toDosServices.GetToDoByID(Convert.ToInt32(id));
            if (toDoLists == null)
            {
                return HttpNotFound();
            }
            return View(toDoLists);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Definition,DueDate,Priority,Attribute")] ToDoLists toDoLists)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool edit = _toDosServices.EditToDo(toDoLists);
                    if (edit)
                    {
                        return RedirectToAction("Index");
                    }

                }
                catch (Exception e)
                {
                    return View("Error", new HandleErrorInfo(e, "ToDoLists", "Edit"));
                }
            }

            return View(toDoLists);

        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ToDoLists toDoLists = _toDosServices.GetToDoByID(Convert.ToInt32(id));
            if (toDoLists == null)
            {
                return HttpNotFound();
            }
            return View(toDoLists);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                bool delete = _toDosServices.DeleteToDo(id);
                if (delete)
                {
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Delete");
            }
            catch (Exception e)
            {
                return View("Error", new HandleErrorInfo(e, "ToDoLists", "Edit"));
            }
        }


    }
}
