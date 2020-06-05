using System;
using System.Collections.Generic;

namespace ProjectCore.DAL.Models
{
    public partial class UserProjects
    {
        public int Id { get; set; }
        public int? ProjectId { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Projects Project { get; set; }
        public virtual AspNetUsers User { get; set; }
    }
}
