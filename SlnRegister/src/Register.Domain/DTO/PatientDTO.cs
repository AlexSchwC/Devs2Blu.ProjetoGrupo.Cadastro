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
    public class PatientDTO
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Condition")]
        public int conditionId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Age")]
        public string age { get; set; }
        public virtual ConditionDTO? condition { get; set; }

        public Patient mapToEntity()
        {
            return new Patient()
            {
                Id = id,
                ConditionId = conditionId,
                Name = name,
                Age = age,
            };
        }
        public PatientDTO mapToDTO(Patient patient)
        {
            return new PatientDTO()
            {
                id = patient.Id,
                conditionId = patient.ConditionId,
                name = patient.Name,
                age = patient.Age
            };
        }
    }
}

