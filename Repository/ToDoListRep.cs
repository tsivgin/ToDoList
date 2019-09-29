using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using ToDoList.DAL;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public class ToDoListRep : IToDoList
    {

        private SchoolContext db = new SchoolContext();


        public ToDoLists AddToDo(ToDoLists item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            db.ToDoLists.Add(item);
            db.SaveChanges();
            return item;
        }

        public bool DeleteToDo(int id)
        {
            try
            {
                ToDoLists ToDoLists = db.ToDoLists.Find(id);
                db.ToDoLists.Remove(ToDoLists);
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public IEnumerable<ToDoLists> GetAllToDo()
        {
            return db.ToDoLists;
        }

        public ToDoLists GetToDoByID(int id)
        {
            return db.ToDoLists.Find(id);
        }
        
        public bool EditToDo(ToDoLists item)
        {
            try
            {
                db.Entry(item).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

    }
}