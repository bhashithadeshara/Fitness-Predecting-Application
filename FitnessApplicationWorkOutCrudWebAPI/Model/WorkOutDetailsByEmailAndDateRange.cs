using System;

namespace FitnessApplicationWorkOutCrudWebAPI
{
    public class WorkOutDetailsByEmailAndDateRange
    {
        public string Email { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
