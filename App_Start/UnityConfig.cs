using System.Web.Mvc;
using ToDoList.Repository;
using Unity;
using Unity.Mvc5;

namespace ToDoList
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IToDoList, ToDoListRep>();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}