using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using FitnessApplicationWorkOutCrudWebAPI.Model;

namespace FitnessApplicationWorkOutCrudWebAPI
{
    public class WorkOutDetail
    {
        [Key]
        public Guid Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public String CheatMeal { get; set; }

        public String WorkOut { get; set; }

        public String WorkOutType { get; set; }

        public double WorkOutDuration { get; set; }

        public DateTime WorkOutDate { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
