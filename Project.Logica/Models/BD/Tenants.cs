using System;

namespace ProjectCore.Logica.Models.BD
{
    public class Tenants
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Plan { get; set; }

    }
}
