﻿using Register.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.DTO
{   
    public class PersonDTO
    {
        [Display(Name = "Id")]
        [Required(ErrorMessage = "{0} is required")]
        public int id { get; set; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "{0} is required")]
        public string name { get; set; }

        [Display(Name = "Age")]
        [Required(ErrorMessage = "{0} is required")]
        public string age { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "{0} is required")]
        public string cpf { get; set; }

        public Person mapToEntity()
        {
            return new Person()
            {
                Id = id,
                Name = name,
                Age = age,
                CPF = cpf
            };
        }
        public PersonDTO mapToDTO(Person person)
        {
            return new PersonDTO()
            {
                id = person.Id,
                name = person.Name,
                age = person.Age,
                cpf = person.CPF
            };
        }
    }
}
