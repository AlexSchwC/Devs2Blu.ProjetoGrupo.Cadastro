using Register.Domain.Entities;
using Register.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Register.Domain.DTO
{
    public class UserDTO
    {
        public int id { get; set; }
        public int personId { get; set; }
        public virtual Person? person { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public PersonTypeEnum? personType { get; set; }

        public User mapToEntity()
        {
            return new User
            {
                Id = this.id,
                PersonId = this.personId,
                Person = this.person,
                Username = this.username,
                Password = this.password,
                Email = this.email,
                PersonType = this.personType,
            };
        }

        public UserDTO mapToDTO(User user) 
        {
            return new UserDTO
            {
                id = user.Id,
                personId = user.PersonId,
                person = user.Person,
                username = user.Username,
                password = user.Password,
                email = user.Email,
                personType = user.PersonType,
            };
        }
    }
}
