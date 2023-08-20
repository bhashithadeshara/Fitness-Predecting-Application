using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessPersonal
{
    public class WorkOutDetail
    {
        public Guid Id { get; set; }

        public double Weight { get; set; }

        public double Height { get; set; }

        public String CheatMeal { get; set; }

        public String WorkOut { get; set; }

        public String WorkOutType { get; set; }

        public double WorkOutDuration { get; set; }

        public DateTime WorkOutDate { get; set; }        
        public Guid UserId { get; set; }

        public User User { get; set; }
    }
}
