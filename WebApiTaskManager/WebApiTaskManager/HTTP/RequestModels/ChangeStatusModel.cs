using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiTaskManager.HTTP.RequestModels
{
    public class ChangeStatusModel
    {

        public int TaskID { get; set; }

        public string Status { get; set; }

    }
}
