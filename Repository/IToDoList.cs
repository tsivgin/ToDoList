using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.Repository
{
    public interface IToDoList
    {
        IEnumerable<ToDoLists> GetAllToDo();
        ToDoLists GetToDoByID(int id);
        ToDoLists AddToDo(ToDoLists item);
        bool EditToDo(ToDoLists item);
        bool DeleteToDo(int id);
    }
}
