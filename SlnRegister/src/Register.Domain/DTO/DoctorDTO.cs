using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Register.Domain.DTO
{
    public class DoctorDTO
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "Specification")]
        public int specialtyId { get; set; }

        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Name")]
        public string name { get; set; }
        [Required(ErrorMessage = "{0} is required")]
        [Display(Name = "Age")]
        public string age { get; set; }
        public virtual SpecialtyDTO? specification { get; set; }

        public Doctor mapToEntity()
        {
            return new Doctor()
            {
                Id = id,
                SpecialtyId = specialtyId,
                Name = name,
                Age = age,
            };
        }
        public DoctorDTO mapToDTO(Doctor doctor)
        {
            return new DoctorDTO()
            {
                id = doctor.Id,
                specialtyId = doctor.SpecialtyId,
                name = doctor.Name,
                age = doctor.Age
            };
        }
    }
}
