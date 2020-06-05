using System;
using System.Collections.Generic;
using System.Linq;

namespace ProjectCore.Logica.BL
{
    public class Projects
    {
        public List<Models.DB.Projects> GetProjects(int? id, int? tenantId, string userId = null)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var listProjectsEF = (from _projects in _context.Projects
                                  select _projects).ToList();

            if (id != null)
                listProjectsEF = listProjectsEF.Where(x => x.Id == id).ToList();

            if (tenantId != null)
                listProjectsEF = listProjectsEF.Where(x => x.TenantId == tenantId).ToList();

            if (!string.IsNullOrEmpty(userId))
                listProjectsEF = (from _projects in listProjectsEF
                                  join _userProjects in _context.UserProjects on _projects.Id equals _userProjects.ProjectId
                                  where _userProjects.UserId.Equals(userId)
                                  select _projects).ToList();


            var listProjects = (from _projects in listProjectsEF
                                select new Models.DB.Projects
                                {

                                    Id = _projects.Id,
                                    Title = _projects.Title,
                                    Details = _projects.Details,
                                    ExpectedCompletionDate = _projects.ExpectedCompletionDate,
                                    TenantId = _projects.TenantId,
                                    CreatedAt = _projects.CreatedAt,
                                    UpdatedAt = _projects.UpdatedAt

                                }).ToList();
            return listProjects;
        }
        public void CreateProjects(string title, string details, DateTime? expectedcompletiondate, int tenantId)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();
            _context.Projects.Add(new DAL.Models.Projects
            {
                Title = title,
                Details = details,
                ExpectedCompletionDate = expectedcompletiondate,
                TenantId = tenantId,
                CreatedAt = DateTime.Now

            });
            _context.SaveChanges();
        }

        public void UpdateProjects(int id, string title, string details,
            DateTime? expectedcompletiondate)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            var projectEF = _context.Projects.Where(x => x.Id == id).FirstOrDefault();

            projectEF.Title = title;
            projectEF.Details = details;
            projectEF.ExpectedCompletionDate = expectedcompletiondate;
            projectEF.UpdatedAt = DateTime.Now;

            _context.SaveChanges();
        }

        public void DeleteProjects(int? id)
        {
            DAL.Models.ProjectCoreContext _context = new DAL.Models.ProjectCoreContext();

            if (_context.Artifacts.Any(x => x.ProjectId == id) || _context.UserProjects.Any(x => x.ProjectId == id))
                return;


            var projectEF = _context.Projects.Where(x => x.Id == id).FirstOrDefault();

            _context.Projects.Remove(projectEF);
            _context.SaveChanges();
        }
    }
}
