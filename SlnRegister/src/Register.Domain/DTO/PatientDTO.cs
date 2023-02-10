﻿using Register.Domain.Entities;
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
        [Required(ErrorMessage = "{0} is required")]
        public int id { get; set; }

        [Display(Name = "Condition")]
        [Required(ErrorMessage = "{0} is required")]
        public int conditionId { get; set; }

        [Display(Name = "PersonId")]
        public int personId { get; set; }


        public Patient mapToEntity()
        {
            return new Patient()
            {
                Id = id,
                ConditionId = conditionId,
                PersonId = personId
            };
        }
        public PatientDTO mapToDTO(Patient patient)
        {
            return new PatientDTO()
            {
                id = patient.Id,
                conditionId = patient.ConditionId,
                personId = patient.PersonId
            };
        }
    }
}