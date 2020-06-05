using ProjectCore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectCore.Logica.Models.BD
{
 public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Effort { get; set; }
        public int? RemainingWork { get; set; }

        //FOREING KEY
        public int? StateId { get; set; }
        public int? ActivityId { get; set; }
        public int? PriorityId { get; set; }
        public int? ProjectId { get; set; }

        public virtual Activities Activities { get; set; }
        public virtual Priorities Priorities { get; set; }
        public virtual Projects Projects { get; set; }
        public virtual States States { get; set; }
    }
}
