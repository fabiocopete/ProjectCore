using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace ProjectCore.Controllers
{
    public class TaskController : Controller
    {
        public IActionResult Index(int? projectId)
        {
            Logica.BL.Task task = new Logica.BL.Task();

            var listTask = task.GetTasks(projectId, null);

            var listTaskViewModel = listTask.Select(x => new Logica.Models.ViewModel.TaskIndexViewModel 
           { 
              Id = x.Id,
              Title = x.Title,
              Details = x.Details,
              ExpirationDate = x.ExpirationDate,
              IsCompleted = x.IsCompleted,
              Effort = x.Effort,
              RemainingWork= x.RemainingWork,
              State = x.States.Name,
              Activity = x.Activities.Name,
              Priority = x.Priorities.Name

           });
            Logica.BL.Projects projects = new Logica.BL.Projects();
            var project = projects.GetProjects(projectId,null).FirstOrDefault();
            ViewBag.Project = project;

            return View(listTaskViewModel);
        }

        public IActionResult Create(int ? projectId)
        {
            var taskBindingModel = new Logica.Models.BindingModel.TaskCreateBindingModel
            {
                ProjectId = projectId
            };
            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            Logica.BL.Priorities priorities  = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorities();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();



            return View(taskBindingModel);
        }
        [HttpPost]
        public IActionResult Create(Logica.Models.BindingModel.TaskCreateBindingModel model)
        {
            if (ModelState.IsValid)
            {
                Logica.BL.Task task = new Logica.BL.Task();
                task.CreateTasks(model.Title, model.Details, model.ExpirationDate, model.IsCompleted, model.Effort
                    , model.RemainingWork, model.StateId, model.ActivityId, model.PriorityId, model.ProjectId);

                return RedirectToAction("Index", new { projectId = model.ProjectId });
            }

            Logica.BL.Activities activities = new Logica.BL.Activities();
            ViewBag.Activities = activities.GetActivities();

            Logica.BL.Priorities priorities = new Logica.BL.Priorities();
            ViewBag.Priorities = priorities.GetPriorities();

            Logica.BL.States states = new Logica.BL.States();
            ViewBag.States = states.GetStates();


            return View(model);
        }

    }


}