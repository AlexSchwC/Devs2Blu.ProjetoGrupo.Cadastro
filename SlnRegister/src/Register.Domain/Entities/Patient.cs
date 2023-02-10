using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.Entities
{
    public class Patient
    {
        public int Id { get; set; }
        public int ConditionId { get; set; }
        public virtual Condition? ConditionList { get; set; }
        public int PersonId { get; set; }
        public virtual Person? Person { get; set; }
    }
}
