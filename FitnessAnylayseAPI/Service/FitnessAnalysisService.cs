using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Text.Json.Serialization;
using System;
using Newtonsoft.Json;
using FitnessAnylayseAPI.Model;

namespace FitnessAnylayseAPI.Service
{
    public class FitnessAnalysisService
    {
        private const string BaseWorkOutDetailUrl = "https://fitnessgatewayservice.azurewebsites.net/apigateway/workoutDetailService";

        List<WorkOutDetail> workOutDetailList = null;

        public AnalyseData anylszeDataByMail (String email)
        {

            workOutDetailList = getWorkOutdetailsByUsermail(email);

            int totalCheatMealCount = 0;
            int totalWorkOutCount = 0;
            double totalWeight = 0;
            double sumBMI = 0;
            double avgBMI = 0;//Body Mass Ratio
            int totalDaysCount = 0;
            double roundedavgCheatMealCount = 0;
            double roundedavgWorkoutCount = 0;
            String bmiStatus = null;
            string fitness = null;
            double futureWeight = 0;
            double roundedPredictedWeight = 0;

            if (workOutDetailList == null || workOutDetailList.Count < 7)
            {
                AnalyseData analyseData = new AnalyseData
                {
                   LessData = true,
                };
                return analyseData;
            }
            else
            {

                double min = double.MaxValue; // Set initial minimum to maximum possible value
                double max = double.MinValue;
                double totalWorkOutDuration = 0;

                //Calculate total daysCount,totalCheatMealCount,totalWorkOutCount
                foreach (var item in workOutDetailList)
                {
                    if (item.Weight < min)
                        min = item.Weight;

                    if (item.Weight > max)
                        max = item.Weight;

                    if (item.WorkOut == "Yes")
                    {
                       totalWorkOutCount++;
                    }
                    if (item.CheatMeal == "Yes")
                    {
                        totalCheatMealCount++;
                    }

                    double BMI = item.Weight / (item.Height / 100 * item.Height / 100);

                    sumBMI += BMI;

                    totalWeight = totalWeight + item.Weight;

                    totalDaysCount++;
                    totalWorkOutDuration = totalWorkOutDuration + item.WorkOutDuration;
                }

                avgBMI = (double)sumBMI / totalDaysCount;

                double avgWorkoutCount = (double)totalWorkOutCount * 100 / totalDaysCount;

                double avgCheatMealCount = (double)totalCheatMealCount * 100 / totalDaysCount;

                double avgWeight = (double)totalWeight / totalDaysCount;


                roundedavgCheatMealCount = Math.Round(avgCheatMealCount, 2);

                roundedavgWorkoutCount = Math.Round(avgWorkoutCount, 2);

                int workOutScore = 0;

                //Calculate workOut Score based on avgWorkoutCount and avgCheatMealCount
                if (avgWorkoutCount == 0 && avgCheatMealCount == 0)
                {
                    workOutScore = 50;
                }
                else if (avgWorkoutCount > avgCheatMealCount)
                {
                    workOutScore = 80;

                }
                else if (avgWorkoutCount == avgCheatMealCount)
                {
                    workOutScore = 50;
                }
                else if (avgWorkoutCount < avgCheatMealCount)
                {
                    workOutScore = 30;
                }


                int bmiScore;

                //Calculate BMI Score based on avgBMI
                if (avgBMI < 18.5)
                {
                    bmiStatus = "Underweight";
                    bmiScore = 50;
                }
                else if (avgBMI > 18.5 && avgBMI < 24.9)
                {
                    bmiStatus = "Normal";
                    bmiScore = 80;
                }
                else if (avgBMI > 25 && avgBMI < 29.9)
                {
                    bmiStatus = "Overweight";
                    bmiScore = 60;
                }
                else if (avgBMI > 30 && avgBMI < 34.9)
                {
                    bmiStatus = "Obesity(Class I)";
                    bmiScore = 50;
                }
                else if (avgBMI > 35 && avgBMI < 39.9)
                {
                    bmiStatus = "Obesity(Class II)";
                    bmiScore = 40;
                }
                else
                {
                    bmiStatus = "Obesity(Class III)";
                    bmiScore = 30;
                }

                //Calculate fitnes Score based on avgBMI
                int fitnesScore = bmiScore + workOutScore;

                //Define fitness based on fitnesScore
                if (fitnesScore >= 160)
                {

                    fitness = "Good";
                }
                else if (fitnesScore >= 120 && fitnesScore < 160)
                {
                    fitness = "Above Average";
                }
                else if (fitnesScore >= 90 && fitnesScore < 120)
                {
                    fitness = "Average";
                }
                else
                {
                    fitness = "Poor";
                }

                double weightdefference = max - min;

                //predict weight based on workout score and inserted weight
                if (workOutScore == 80)
                {
                    futureWeight = avgWeight - weightdefference;
                }
                else if (workOutScore == 50)
                {
                    futureWeight = avgWeight;
                }
                else if (workOutScore == 30)
                {
                    futureWeight = avgWeight + weightdefference;
                }

                roundedPredictedWeight = Math.Round(futureWeight, 1);



                AnalyseData analyseData = new AnalyseData
                {
                    TotalCheatMealCount = totalCheatMealCount,
                    TotalWorkOutCount = totalWorkOutCount,
                    TotalWeight = totalWeight,
                    SumBMI = sumBMI,
                    AvgBMI = avgBMI,
                    TotalDaysCount = totalDaysCount,
                    RoundedavgCheatMealCount = roundedavgCheatMealCount,
                    RoundedavgWorkoutCount = roundedavgWorkoutCount,
                    BmiStatus = bmiStatus,
                    Fitness = fitness,
                    FutureWeight = futureWeight,
                    RoundedPredictedWeight = roundedPredictedWeight,
                    WorkOutDetailList = workOutDetailList
                };

                return analyseData;

            }            
        }

        public List<WorkOutDetail> getWorkOutdetailsByUsermail(string email)
        {
            

            // Send the GET request to the API
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(BaseWorkOutDetailUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    // Append the email parameter to the URL
                    HttpResponseMessage response = client.GetAsync($"{BaseWorkOutDetailUrl}/email/{email}").Result;

                    if (response.IsSuccessStatusCode)
                    {
                        // The request was successful, handle the response
                        string responseBody = response.Content.ReadAsStringAsync().Result;
                        workOutDetailList = JsonConvert.DeserializeObject<List<WorkOutDetail>>(responseBody);

                        return workOutDetailList;

                    }
                    else if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        // Handle the case where the user or workout details are not found
                        // You can display an error message to the user if needed
                        return workOutDetailList;
                    }
                    else
                    {
                        // The request failed, handle the error
                        return workOutDetailList;
                    }
                }
                catch (HttpRequestException ex)
                {
                    return workOutDetailList;
                }
            }
        }
    }
}
