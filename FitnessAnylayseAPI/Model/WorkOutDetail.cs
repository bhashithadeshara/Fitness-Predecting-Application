using System.ComponentModel.DataAnnotations;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace FitnessAnylayseAPI.Model
{
    public class WorkOutDetail
    {
        [Key]
        public Guid Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public string CheatMeal { get; set; }

        public string WorkOut { get; set; }

        public string WorkOutType { get; set; }

        public double WorkOutDuration { get; set; }

        public DateTime WorkOutDate { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
