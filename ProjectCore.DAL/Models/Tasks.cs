using System;
using System.Collections.Generic;

namespace ProjectCore.DAL.Models
{
    public partial class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public bool? IsCompleted { get; set; }
        public int? Effort { get; set; }
        public int? RemainingWork { get; set; }
        public int? StateId { get; set; }
        public int? ActivityId { get; set; }
        public int? PriorityId { get; set; }
        public int? ProjectId { get; set; }

        public virtual Activities Activity { get; set; }
        public virtual Priorities Priority { get; set; }
        public virtual Projects Project { get; set; }
        public virtual States State { get; set; }
    }
}
