using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ProjectCore.Logica.BL
{
    public class Task
    {
        public List<Models.BD.Task> GetTasks(int? projectId, int? id)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();
            var listTask = (from _task in _context.Tasks
                            join _states in _context.States on _task.StateId equals _states.Id

                            join _activities in _context.Activities on _task.ActivityId equals _activities.Id
                            join _priorities in _context.Priorities on _task.PriorityId equals _priorities.Id
                            select new Models.BD.Task {
                                Id = _task.Id,
                                Title = _task.Title,
                                Details = _task.Details,
                                ExpirationDate = _task.ExpirationDate,
                                IsCompleted = _task.IsCompleted,
                                Effort = _task.Effort,
                                RemainingWork = _task.RemainingWork,
                                StateId = _task.StateId,

                                States = new Models.BD.States
                                {
                                    Name = _states.Name
                                },
                                PriorityId = _task.PriorityId,
                                Priorities = new Models.BD.Priorities
                                {
                                    Name = _priorities.Name
                                },
                                ActivityId = _task.ActivityId,
                                Activities = new Models.BD.Activities
                                {
                                    Name = _activities.Name
                                },
                                ProjectId = _task.ProjectId,


                            }).ToList();

            if (projectId != null)

                listTask = listTask.Where(x => x.ProjectId == projectId).ToList();
            if (id != null)
                listTask = listTask.Where(x => x.Id == id).ToList();

            return (listTask);
            
            
        }

        //CREAR TAREAS
        public void CreateTasks(string title, string details, DateTime? expirationDate, bool? iscomplete,
            int? effort , int? remainingwork , int? stateId, int? activityId , int? priorityId ,int? projectId)
        {

            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            _context.Tasks.Add(new DAL.Models.Tasks { 
            
            Title = title,
            Details= details,
            ExpirationDate = expirationDate,
            IsCompleted = iscomplete,
            Effort= effort,
            RemainingWork= remainingwork,
            StateId= stateId,
            ActivityId= activityId,
            PriorityId= priorityId,
            ProjectId= projectId
                
            });

            _context.SaveChanges();
        }
    }
}
