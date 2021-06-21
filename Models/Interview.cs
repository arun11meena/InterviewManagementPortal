using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewManagementPortal.Models
{
    public class Interview
    {
        public int Id { get; set; }

        public List<Participant> Participants { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
    
}
