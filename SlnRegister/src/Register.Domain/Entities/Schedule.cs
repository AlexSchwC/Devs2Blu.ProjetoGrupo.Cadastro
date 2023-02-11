using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        public DateTime SchedulingDate { get; set; }
        public string Situation { get; set; }
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }
        public int DoctorId { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
