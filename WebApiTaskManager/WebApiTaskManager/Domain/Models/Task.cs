using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.Domain.Models
{
    public class Task
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string TimeEstimation { get; set; }
        public string Status { get; set; }


        public int ProjectID { get; set; }
        [ForeignKey("ProjectID")]
        public virtual Project Project { get; set; }

        public int? MemberID { get; set; }
        [ForeignKey("MemberID")]
        public virtual Member Member { get; set; }
    }
}
