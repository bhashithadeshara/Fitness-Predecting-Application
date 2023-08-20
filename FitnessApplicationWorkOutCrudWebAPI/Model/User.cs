using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FitnessApplicationWorkOutCrudWebAPI.Model
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        [JsonIgnore]
        public ICollection<WorkOutDetail> UserWorkOutDetails { get; set; }

    }
}
