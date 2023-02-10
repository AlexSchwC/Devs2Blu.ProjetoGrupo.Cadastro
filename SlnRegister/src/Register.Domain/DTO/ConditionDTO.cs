using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Register.Domain.DTO
{
    public class ConditionDTO
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Name")]
        public string name { get; set; }
        public virtual ICollection<PatientDTO>? patientList { get; set; }
        public Specialty mapToEntity()
        {
            return new Specialty
            {
                Id = this.id,
                Name = this.name,
            };
        }
        public SpecialtyDTO maptoDTO(Specialty specialty)
        {
            return new SpecialtyDTO
            {
                id = specialty.Id,
                name = specialty.Name,
            };
        }
    }
}
