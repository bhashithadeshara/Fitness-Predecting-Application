using System;
using System.Collections.Generic;

namespace FitnessPersonal.Model
{
    public class AnalyseData
    {
        public int TotalCheatMealCount { get; set; }

        public int TotalWorkOutCount { get; set; }

        public double TotalWeight { get; set; }

        public double SumBMI { get; set; }

        public double AvgBMI { get; set; }

        public int TotalDaysCount { get; set; }

        public double RoundedavgCheatMealCount { get; set; }

        public double RoundedavgWorkoutCount { get; set; }

        public String BmiStatus { get; set; }

        public string Fitness { get; set; }

        public double FutureWeight { get; set; }

        public double RoundedPredictedWeight { get; set; }

        public List<WorkOutDetail> WorkOutDetailList { get; set; }

        public Boolean LessData { get; set; }
    }
}
