using Azure;
using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.DTO
{
    public class ReceptionistDTO
    {
        [Display(Name = "Id")]
        public int id { get; set; }
        [Display(Name = "PIS Number")]
        public string pis { get; set; }
        public int personId { get; set; }

        public Receptionist mapToEntity()
        {
            return new Receptionist()
            {
                PIS = this.pis,
                PersonId = this.personId
            };
        }
        public ReceptionistDTO mapToDTO(Receptionist receptionist)
        {
            return new ReceptionistDTO()
            {
                personId = receptionist.PersonId,
                pis = receptionist.PIS
            };
        }
    }
}
