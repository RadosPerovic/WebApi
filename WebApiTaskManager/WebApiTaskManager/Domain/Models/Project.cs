using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.Domain.Models
{
    public class Project
    {
        [Key]
        public int ID { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        
        public virtual IList<Member> Members { get; set; }

        public virtual IList<Task> Tasks { get; set; } 
    }
}
